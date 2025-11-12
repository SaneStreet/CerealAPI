# 1️⃣ Start from node
FROM node:24-alpine

# 2️⃣ Work directory
WORKDIR /app

# 3️⃣ Copy package.json & install dependencies
COPY package*.json ./
RUN npm install

# 4️⃣ Copy frontend code
COPY . .

# 5️⃣ Expose Vite
EXPOSE 5173

# 6️⃣ Start dev-server
CMD ["npm", "run", "dev", "--", "--host"]
