# build-stage
FROM node:13.14-alpine as build-stage
WORKDIR /vueApp
COPY . .
# production stage
FROM nginx:1.17.5-alpine as production-stage
COPY --from=build-stage /vueApp /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]