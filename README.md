# GestYou — Sistema de Gestão Financeira em Grupo

O **GestYou** é uma aplicação **full stack** desenvolvida para auxiliar na **organização financeira em grupo**, permitindo o controle de **receitas e despesas** de forma simples.

O projeto é dividido em **frontend** e **backend**, seguindo boas práticas de separação de responsabilidades, facilitando manutenção, escalabilidade e evolução futura.

---

## Funcionalidades

-  Registro e gerenciamento de **receitas e despesas**
-  Registro e gerenciamento de **Pessoas**
-  Registro e gerenciamento de **Categorias**
-  Comunicação via **API REST**
---

## Tecnologias Utilizadas
<img src="https://skillicons.dev/icons?i=cs,dotnet,postgresql,ts,nodejs,react,nextjs" />

## 🧩 Instalação e Execução

### 1️⃣ Clonar o Repositório

``` bash
git clone https://github.com/BernardoSsilva/GestYou.git
cd GestYou
```

------------------------------------------------------------------------
## 🐳 Execução com Docker (Recomendado)

Com o Docker em execução, utilize o Docker Compose para subir o container do bancod de dados:

``` bash
docker compose up --build
```

### 2️⃣ Backend --- API (.NET)

``` bash
cd web-api
dotnet restore
dotnet build
dotnet run
```

------------------------------------------------------------------------

### 3️⃣ Frontend --- Aplicação Web

``` bash
cd frontend
npm install
npm run dev
```

📌 A aplicação ficará disponível normalmente em:\
`http://localhost:3000`
