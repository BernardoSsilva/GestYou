# 💰 GestYou — Financial Management System

## 📌 Sobre o Projeto

O **GestYou** é uma aplicação **full stack** desenvolvida como parte de um **desafio técnico proposto pela empresa Maxiprod**.

O objetivo foi construir um sistema para **organização financeira**, permitindo o controle de **entradas e saídas**, categorização e gerenciamento de usuários envolvidos.

A solução foi projetada com foco em **boas práticas de arquitetura**, separação de responsabilidades e escalabilidade.

---

## 🎯 Objetivo do Desafio

Desenvolver uma aplicação capaz de:

* Gerenciar **receitas e despesas**
* Organizar dados financeiros de forma estruturada
* Garantir uma base sólida para evolução futura

---

## 🧠 Arquitetura

O backend foi desenvolvido utilizando **Domain-Driven Design (DDD)**, garantindo:

* Separação clara de responsabilidades
* Código mais organizado e testável
* Facilidade de manutenção e evolução

### 🔹 Camadas da aplicação:

* **Domain** → Regras de negócio e entidades
* **Application** → Casos de uso
* **Infrastructure** → Persistência e integrações
* **API** → Exposição dos endpoints REST

---

## ⚙️ Tecnologias Utilizadas

### Backend

* .NET
* PostgreSQL
* Arquitetura DDD
* Testes unitários

### Frontend

* Next.js
* React
* shadCN UI

---

## 🚀 Funcionalidades

* 📥 Registro de **receitas**
* 📤 Registro de **despesas**
* 👤 Gerenciamento de **pessoas**
* 🗂️ Gerenciamento de **categorias**
* 🔗 Integração completa via **API REST**

---

## 🧪 Testes

O backend possui **testes unitários**, garantindo:

* Maior confiabilidade das regras de negócio
* Facilidade de manutenção
* Segurança em futuras alterações

---

## 🐳 Execução do Projeto

### 🔹 Clonar repositório

```bash
git clone https://github.com/BernardoSsilva/GestYou.git
cd GestYou
```

---

### 🔹 Subir banco com Docker

```bash
docker compose -f database-compose.yml up
```

---

### 🔹 Backend (.NET)

```bash
cd web-api
dotnet restore
dotnet build
dotnet run
```

---

### 🔹 Frontend (Next.js)

```bash
cd frontend
npm install
npm run dev
```

📌 A aplicação estará disponível em:
http://localhost:3000

---

## 📈 Possíveis Melhorias

* Autenticação e autorização de usuários
* Deploy em ambiente cloud
* Testes de integração
* Dashboard com visualização de dados financeiros
* Suporte a múltiplos grupos/contas

---

## 💬 Considerações Finais

Este projeto demonstra:

* Capacidade de desenvolver aplicações **full stack**
* Aplicação de **boas práticas de arquitetura (DDD)**
* Escrita de código **testável e organizado**
* Construção de soluções voltadas para problemas reais

---
