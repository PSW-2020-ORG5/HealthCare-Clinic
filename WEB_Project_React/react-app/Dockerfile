FROM node:10-alpine as build-step
WORKDIR /app
COPY . .
# Stage 2
FROM nginx:1.17.1-alpine
COPY --from=build-step /app/build /usr/share/nginx/html