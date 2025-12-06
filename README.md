DOCUMENTACIÓN DE IMPLEMENTACIÓN – LOGITRACK (Evaluación Técnica – 8 horas)

Durante la prueba técnica de 8 horas, implementé una arquitectura modular basada en principios de Clean Architecture, con las capas Domain, Application e Infrastructure, logrando construir:

Modelo de dominio inicial (entidades, DTOs, mappers).

CRUD básico del agregado Package.

Conectividad real con SQL Server en Docker.

Preparación de arquitectura para mensajería (RabbitMQ en Docker, sin integración final).

Endpoints funcionales (el único completo fue Create Package, con su lógica de caso de uso y repositorio).

Estructura modular con repositorios, casos de uso, mappers y endpoints en una arquitectura separada.

Validación básica de datos, separación por capas y DI.

Estructura lista para pruebas unitarias (por tiempo, no fueron implementadas).

El alcance realizado está completamente alineado con el tiempo disponible: 8 horas no permiten completar un sistema tipo Dev Crack, pero sí una base sólida de arquitectura modular y un CRUD parcial funcional.

Arquitectura Implementada

Arquitectura Modular (Clean Architecture Lite)

Se implementaron 3 capas:

Domain

Entidades y reglas de negocio.

Modelos: Package, PackageStatus.

DTOs y estructuras relacionadas.

Encapsulación de datos.

Separación clara del framework.

Application

Casos de uso.

Interfaces de repositorios (puertos).

Lógica orquestadora del CRUD.

Infrastructure

Implementación de repositorios.

Conexión a SQL Server vía Docker.

Mappers entre entidades y DTOs.

Exposición de API por endpoints minimalistas (.NET).

Funcionalidades Implementadas

1. Modelo de Dominio

Implementé:

Entidad Package

Estructura para dimensiones y destinatario

Estado inicial del paquete

Preparación para historial de ubicaciones

No se implementó:

La máquina de estados completa

Builder/Factory avanzado

Justificación:
Modelar un dominio completo con máquinas de estados, builder, invariantes y transiciones válidas toma entre 6 y 10 horas solo para el dominio. En 8 horas no era realista abarcar la profundidad requerida para “Expert” o “Crack”.

2. CRUD Básico

Implementé:

Create Package

Caso de uso completo

Repositorio funcional

Endpoint funcionando

Validación y mapeo de DTO → Dominio → Persistencia

Lo que quedó pendiente por tiempo:

Update Package

Delete Package

Get Package By Id

Get All Packages

Justificación:
Completar un CRUD completo con Clean Architecture implica:

4 casos de uso

4 rutas

4 mappers

4 repositorios o métodos en repositorio

Manejo de errores + validaciones + DTOs

Pruebas unitarias

Eso requiere mínimo 6–8 horas más.

3. Repositorios

Implementé repositorio para persistir Package.

Almacenamiento en SQL Server mediante Dapper o EF (según implementación).

Conexión validada desde SQL Server Management Studio.

No se implementó:

Repositorios para historial de ubicaciones

Query avanzada ni CQRS

Versionamiento (optimistic locking)

4. Conexión a SQL Server

Se creó un Docker Compose funcional para SQL Server.

La aplicación se conectó con éxito usando cadena de conexión.

Se validó la conexión mediante SSMS.

El modelo y tablas quedaron creadas y listas.

5. Integración RabbitMQ (Parcial)

Realizado:

Docker Compose para RabbitMQ

Contenedor operativo

Management UI accesible

Pendiente:

Publicación de eventos

Suscripción o consumidor

Implementación de Outbox

Justificación:
Implementar mensajería asíncrona con eventos de dominio, integración con casos de uso y capa de infraestructura toma entre 4–6 horas adicionales.

6. Mappers

Se implementaron mappers para Package.

Alineados al uso con AutoMapper.

7. DTOs y Endpoints

DTOs para creación y transporte de datos.

Endpoints minimalistas para modular monolith.

Create quedó completamente funcional.

8. Pruebas Unitarias – No Implementadas

Justificación Técnica:

Pruebas unitarias de:

Dominio (entidad package)

Casos de uso

Repositorios

Cliente HTTP (si se implementara)

Validaciones

Reglas de negocio

Requieren tiempo aproximado: 4–6 horas adicionales.

Justificación del Alcance (Por qué es realista para 8 horas)

La prueba describe niveles Essential → Expert → Crack, donde:

Essential es un CRUD básico con dominio simple.

Expert implica API, seguridad, validaciones, eventos, estado, persistencia, pruebas.

Crack implica microservicios, Outbox, mensajería, CQRS, observabilidad, contract testing, logs estructurados, Kubernetes y más.

El nivel solicitado supera por mucho lo que puede producirse en 8 horas.

Estimación Realista del Trabajo Completo:

Tarea	Horas
Dominio + máquina de estados	8h
CRUD + Casos de uso completos	6h
Integración SQL Server	1–2h
Integración RabbitMQ + eventos	6h
CQRS/Read model	4h
Seguridad API Key + Roles	2h
Docker Compose completo	1h
Pruebas unitarias + integración	6–8h
Documentación + EVALUATION.md	3h
Observabilidad/logging	2h
Total	39–42h

En 8 horas se puede cubrir:

Arquitectura base

Entidades

Repositorios

Casos de uso esenciales

Un endpoint funcional

Conexiones y contenedores

DTOs y mappers

Parte del CRUD

…y eso es exactamente lo que se logró.

Conclusión

Lo realizado:

Entidad Package completa.

Arquitectura modular bien separada.

SQL Server y RabbitMQ montados en Docker.

Repositorios + DI + Application layer.

Endpoint Create funcional.

Caso de uso Create completo.

Mappers, DTOs y validaciones iniciales.

Lo que faltó (pero era esperado por tiempo):

CRUD completo

RabbitMQ integrado

Máquina de estados

Cliente REST externo

Pruebas unitarias

CQRS

Outbox

Logging estructurado

Seguridad API Key

Contract Testing

Justificación profesional:
“En 8 horas prioricé construir una arquitectura modular sólida, dejando la base lista para escalar al nivel solicitado (Expert/Crack). Implementé los elementos más críticos: dominio, casos de uso, repositorios, endpoints, SQL Server y RabbitMQ en contenedores. Debido al tiempo limitado, prioricé calidad en las capas centrales en lugar de completar toda la funcionalidad extensa requerida por la prueba.”