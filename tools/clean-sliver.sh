#!/usr/bin/env bash
set -euo pipefail

for id in {0..100}; do
  sudo sqlite3 /root/.sliver/sliver.db "BEGIN IMMEDIATE; DELETE FROM http_listeners WHERE listener_job_id IN (SELECT id FROM listener_jobs WHERE job_id = $id); DELETE FROM listener_jobs WHERE job_id = $id; COMMIT;"
done
