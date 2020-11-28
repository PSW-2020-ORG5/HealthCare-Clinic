FROM node:10-alpine as build-step

FROM nginx:1.17.1-alpine
COPY --from=build-step /build /usr/share/nginx/html