
# Step 1

FROM node:10-alpine as build-step

WORKDIR /appReact

COPY manifest.json /appReact

RUN ls /appReact/

COPY . /appReact

RUN ls /appReact/

# Stage 2

FROM nginx:1.17.1-alpine

COPY --from=build-step /appReact /usr/share/nginx/html