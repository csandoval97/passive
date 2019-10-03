#!/bin/bash
set -e

DIR=$(dirname $(dirname $0))

if [ -f $DIR/.env ]; then
    source $DIR/.env
fi

SHA=$(git rev-parse --verify --short HEAD)

docker login --username=$REGISTRY_USERNAME --password=$REGISTRY_PASSWORD $REGISTRY_HOST
docker push uicacm/passive:$SHA
docker push uicacm/passive:latest
