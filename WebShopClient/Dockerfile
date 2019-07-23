### STAGE 1: Build ###
# Alpine image of node (lightweight)
FROM node:alpine as builder
#Copy package.json and package-lock.json
COPY package*.json ./
## Storing node modules on a separate layer will prevent unnecessary npm installs at each build
RUN npm i && mkdir /builddir && cp -R ./node_modules ./builddir
# Set working directory
WORKDIR /builddir
# Copy everything else to the working directory
COPY . .
## Build the angular app in production mode and store the artifacts in dist folder
RUN $(npm bin)/ng build --prod

### STAGE 2: Setup ###
# Alpine image of nginx
FROM nginx:alpine
## Remove default nginx website
RUN rm -rf /usr/share/nginx/html/*
## Copy our default nginx config
COPY --from=builder nginx.conf /etc/nginx/nginx.conf
## From ‘builder’ stage copy over the artifacts in dist folder to default nginx public folder
COPY --from=builder /app/dist /usr/share/nginx/html