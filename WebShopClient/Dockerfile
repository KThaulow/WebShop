## Stage 0, "build-stage", based on Node.js, to build and compile Angular
# Node.js docker images with dependencies and Nginx configuration
FROM node:alpine as build-stage
# Set working directory
WORKDIR /app
# Copy package.json and package-lock.json
COPY ./package.json ./
# Install dependencies from package.json
RUN npm install
# Copy code to directory
COPY . .
# Set configuration to production for Angular build
# ARG configuration=production
# Build and set variables for ng    
RUN npm run build

# RUN npm run build -- --output-path=./dist/out --configuration $configuration

## Stage 1, based on Nginx, to have only the compiled app, ready for production with Nginx
# Get Nginx web server image
FROM nginx:alpine
# Copy compiled app from stage 0 to nginx
COPY --from=build-stage /app/dist/* /usr/share/nginx/html
# # Override default nginx conf with nginx.conf provided in tiangolo/node-frontend to enable Angular router
# COPY --from=build-stage /nginx.conf /etc/nginx/conf.d/default.conf