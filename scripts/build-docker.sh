#!/bin/bash
set -e

DIR=$(dirname $( cd "$(dirname "$0")" ; pwd -P ))
SHA=$(git rev-parse --verify --short HEAD)

docker build -t uicacm/passive:$SHA $DIR
docker tag uicacm/passive:$SHA uicacm/passive:latest
