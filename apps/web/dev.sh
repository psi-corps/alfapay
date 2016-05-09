#!/bin/bash
clear
echo "Preparing DEV environment..."
npm install && gulp dev:clean && gulp dev:run && gulp dev:clean