FROM node:12.13 as node

COPY . . 
RUN npm install
RUN npm run build --prod

FROM nginx:alpine
COPY --from=node /app/dist/usersngularrepresentation /usr/share/nginx/html