FROM node:12

ENV PATH /app/node_modules/.bin:$PATH

WORKDIR /app

COPY . .
RUN npm ci

EXPOSE 4200
CMD ng serve --host 0.0.0.0
