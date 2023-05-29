# TravelPathFinder
El alcance de este proyecto es desarrollar una solución web para conectar viajes a través del mundo. La solución consistirá en una API que permita calcular rutas de viaje basadas en vuelos disponibles y un front-end que permita a los usuarios ingresar los detalles de origen y destino y ver la ruta sugerida.


## Metas:

1. Crear una API que permita consultar los vuelos disponibles y calcular rutas de viaje en base a los datos proporcionados.
2. Desarrollar un front-end que permita a los usuarios ingresar los detalles de origen y destino, mostrar la ruta sugerida y permitir la selección de monedas para ver los valores equivalentes.
3. Implementar pruebas unitarias para verificar la funcionalidad de la API y el front-end.
4. Documentar adecuadamente el proyecto, incluyendo la documentación de la API y cualquier instrucción necesaria para ejecutar y desplegar la solución.

## Requisitos Funcionales
1. Registro de usuarios: Este requisito no se menciona explícitamente en el enunciado, pero puede considerarse como una funcionalidad adicional que permitiría a los usuarios acceder a funcionalidades personalizadas y guardar preferencias. Aunque no está mencionado, podría ser una buena adición al proyecto si se considera relevante.
2. Ingreso de detalles de viaje: Este requisito se cumple con el problema 4, donde se solicita un formulario web donde los usuarios puedan ingresar los campos de origen y destino.
+Consulta de vuelos disponibles: Este requisito se cumple con el problema 2, donde se consume una API para obtener los vuelos disponibles según los parámetros de origen y destino ingresados.
3. Cálculo de la ruta de viaje: Este requisito se cumple con el problema 3, donde se expone una API que permite calcular la ruta de viaje basada en los vuelos disponibles y los parámetros de origen y destino.
4. Mostrar detalles de la ruta: Este requisito se cumple con la estructura del modelo de respuesta en el problema 3, donde se proporciona información detallada sobre cada vuelo de la ruta, incluyendo aeropuertos de origen y destino, números de vuelo y precios.
5. Selección de moneda: Este requisito se cumple con el problema 5, donde se menciona que el usuario debe tener la posibilidad de seleccionar la moneda en la que desea ver los valores de los vuelos y convertir los precios correspondientemente.
6. Validación de campos: Este requisito se cumple con el problema 4, donde se menciona que los campos de origen y destino deben cumplir con reglas específicas, como la longitud de caracteres y el formato adecuado funcionamiento.

# Notas
Estan implementados los 4 primeros problemas, en el backend aparecen DTOs y manejo de Cache, sin embargo el fronEnd por cuestionmes de tiempo no pude implementarlo con todas las buenas practicas neecsarias, solo permite la busqueda de rutas multiples de ida, pero le falta refactoprizar para hacerlo de mejor calidad.
La falta de implementación del problema 5, asi como de algunas de las condiciones de implementación se debió sobre todo a cuestiones de tiempo.



## Notas Arquitectura
La arquitectura que plantee para la solución es Clean Arquitecture y capas, la siguiente es la estructura general de esta arquitectura

├───BackEnd

│   ├───Core   

│   │   │       

│   │   ├───Domain

│   │   │   ├───Entities

│   │   │   ├───Exceptions

│   │   │   └───Handlers

│   │   ├───Mappings

│   │   ├───Repositories

│   │   └───Services

│   ├───Infrastructure

│   │   ├───API

│   │   │   ├───.vscode

│   │   │   ├───Controllers

│   │   │   └───Properties

│   │   └───Services

│   │       ├───Clients

│   │       ├───DTOs

│   │       ├───Exceptions

│   └───Tests

└───FrontEnd

    ├───BlazorApp
    
    │   ├───Pages
    
    │   ├───Properties
    
    │   ├───Shared
    
    │   └───wwwroot
    
    └───ConsoleApp
    
#### BackEnd: 
Este directorio contiene todo el código y los componentes relacionados con  el backend de la aplicación.

***Core***: Aquí se encuentra la lógica central de la aplicación, incluyendo el dominio del negocio y la lógica del servicio.

+ ***Domain***: Contiene las entidades del dominio, que representan los conceptos fundamentales de la aplicación.
  +  *Entities*: Las entidades representan los objetos principales en el dominio del negocio.
+ ***Mappings***: Aquí se definen las clases y métodos de mapeo utilizados para convertir objetos entre diferentes representaciones (por ejemplo, de entidades a DTOs).
+ ***Repositories***: Este directorio contiene las implementaciones de los repositorios, que se encargan de interactuar con el almacenamiento de datos, como una base de datos.
+  ***Services***: Aquí se encuentran las implementaciones de los servicios de la aplicación, que encapsulan la lógica de negocio y se utilizan para realizar operaciones y manipular datos.

***Infrastructure***: Este directorio contiene el código relacionado con la infraestructura de la aplicación, como la interfaz de programación de aplicaciones (API) y los servicios externos.

+ ***API***: En esta carpeta se encuentran los controladores de la API, que definen los endpoints y manejan las solicitudes HTTP.

+ ***Services***: Aquí se encuentran los servicios relacionados con la infraestructura, como servicios para interactuar con servicios externos o integraciones.


#### FrontEnd: 
Este directorio contiene todo el código y los componentes relacionados con la parte frontal (frontend) de la aplicación.

+ ***BlazorApp***: Aquí se encuentra el proyecto Blazor, que es un framework de desarrollo web de Microsoft.

  + *Pages*: Contiene las páginas de la aplicación Blazor, que son componentes que representan las diferentes vistas y funcionalidades de la aplicación.
  + *Shared*: Aquí se encuentran los componentes compartidos que se pueden utilizar en varias páginas.
  
+ ***ConsoleApp***: Este directorio podría contener una aplicación de consola, que se utiliza para realizar tareas específicas o para ejecutar comandos en la línea de comandos.

## Acceso
### API
[Busqueda de rutas](https://travelpathfinderapi.azurewebsites.net/api/Journey/calculate-routes?origin=MZL&destination=BOG)
### App

[Busqueda de rutas](https://journeyroute.azurewebsites.net/)

