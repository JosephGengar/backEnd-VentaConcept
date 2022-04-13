## BackEnd del Proyecto VentasConcept

Este proyecto es una api hecha en C#, la cual es consumida por el proyecto en angular de VentasConcept, permite agregar ventas con conceptos 
diferentes e ir recibiendo y mostrando los datos en una tabla, en esta api se puede recibir un modelo y envia un objeto
que contiene 3 propiedades:

exito: que puede ser 0 para un error y 1 para confirmar la respuesta correcta.

data: que puede contener cualquier objeto de este tipo, en este caso se va a llenar de una coleccion de datos.

mensajes: que es una propiedad extra, si queremos recibir un mensaje expecifico dependiendo de la respuesta.

Proyecto en Angular que consume la api: https://github.com/JosephGengar/Front-Ang-VentasConcept

Muestra con Postman de los datos que envia la api:

![ventCon1](https://user-images.githubusercontent.com/102115164/163210776-dc79a841-2a20-4b61-971d-1cf936497440.png)

![venCon2](https://user-images.githubusercontent.com/102115164/163210809-64c991fb-139d-4003-9e32-0fb83dd2844a.png)


Tecnologias Utilizadas: Lenguaje C# con Visual Studio Net Core, Entity Framework, SqlServer y Postman.
