#!/bin/bash

DATABASE_URL=$(heroku config:get JAWSDB_URL)

# Use environment variables for Heroku deployment
SERVER=${DB_HOST:-localhost}
DATABASE=${DB_NAME:-Registrar}
USER=${DB_USER:-root}
PASSWORD=${DB_PASSWORD:-}
PORT=${DB_PORT:-3306}
CHARSET="utf8"
SSL_MODE="none"

# Path to the SQL file (assuming it's in the root directory)
SQL_FILE="./Registrar.sql"

# Run the SQL file against the database
mysql --host=$SERVER --port=$PORT --user=$USER --password=$PASSWORD --database=$DATABASE --default-character-set=$CHARSET --ssl-mode=$SSL_MODE < $SQL_FILE

# Check if the command was successful
if [ $? -eq 0 ]; then
  echo "SQL script executed successfully."
else
  echo "Failed to execute SQL script."
  exit 1
fi