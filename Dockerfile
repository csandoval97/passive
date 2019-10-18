FROM node:latest

ENV PATH /app/node_modules/.bin:$PATH

WORKDIR /app

COPY package.json package.json
RUN npm install

COPY . .

EXPOSE 4200
CMD ng serve --host 0.0.0.0
