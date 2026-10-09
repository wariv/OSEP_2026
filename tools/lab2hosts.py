#!/usr/bin/env python3
import argparse
import ipaddress
import re
import tkinter as tk
from pathlib import Path

parser = argparse.ArgumentParser(description="Extract host entries from lab text")

source = parser.add_mutually_exclusive_group(required=True)
source.add_argument("-f", "--file", type=Path, help="File containing the lab text")
source.add_argument("-c", "--clip", action="store_true", help="Read text from the clipboard")

parser.add_argument("-d", "--domain", default="", help="Domain to use later")
args = parser.parse_args()

domain = args.domain

if args.clip:
    try:
        root = tk.Tk()
        root.withdraw()
        try:
            text = root.clipboard_get()
        finally:
            root.destroy()
    except tk.TclError as exc:
        parser.error(f"Could not read text from the clipboard: {exc}")
else:
    try:
        text = args.file.read_text(encoding="utf-8-sig")
    except OSError as exc:
        parser.error(f"Could not read {args.file}: {exc}")

lines = text.splitlines()
header = re.compile(r"^IP\s+\d+\s*-\s*(\S+)\s*$", re.IGNORECASE)

print("\n\n")
for index, line in enumerate(lines):
    match = header.match(line.strip())
    if not match:
        continue

    hostname = match.group(1)
    ip = next((s for s in (line.strip() for line in lines[index + 1:]) if s), None)

    if ip is None:
        parser.error(f"No address found after {hostname}")

    try:
        ipaddress.IPv4Address(ip)
    except ValueError:
        parser.error(f"Invalid address after {hostname}: {ip}")

    print(f"{ip:<18}{hostname.upper():<15}{hostname.upper()}.{domain}")