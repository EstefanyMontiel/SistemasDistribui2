package peer

import (
	"bufio"
	"fmt"
	"net"

)
var username string

func StarListening (port string, user string){
	/* 
	StarListening: inicia un servidor que escucha conexiones entrantes
	port : puerto para abrir conexion  
	user: nombre de usuario
	*/

	username=user  //Guarda el nombre de usuario en la variable global
	listener, err := net.Listen("tcp",":"+port)
	/*
	Abre un servidor TCP que escucha al puerto especificado
	si surge un error al abrir el puerto se alamacena en la variable err
	*/
	if err != nil {
		fmt.Println("Error Listening:", err.Error())
		return
	}
	//Si err no es nulo,imprime un mensaje de error y termina la ejecucion


	defer listener.Close() 
	fmt.Printf("Peer is listening on port %v ...", port ) 
	//fmt muestra el mensaje indicado que el servidor esta escuchadno en el puerto especificado
		for{
			conn, err := listener.Accept()
			/*Acepta la conexion entrante,espera hasta que un cliente se conecte
			 y devuelve la conexión */
			if err != nil{
				fmt.Println("Error accepting connections:", err.Error())
				continue 
			}
			/*Si hay un error, muestra un mensaje y 
			continúa esperando nuevas conexiones (continue).*/
			go receiveMessage(conn) //permite recibir mensajes sin bloquear el programa principal.
			sendMessage(conn)/*
			Llama a sendMessage(conn), que envía un mensaje al cliente.
			Como sendMessage se ejecuta después de go receiveMessage(conn), 
			el programa primero empieza a recibir mensajes y luego envía uno.*/
		}
}


func ConnectToPeer (address string, user string){
	/* Intenta conectarse a otro usuario que ya esta escuchando conexiones 
	addres: direccion ip y puerto del otro usuario
	user: nombre del usuario */
	username = user 
	conn, err := net.Dial("tcp", address)
	//net.Dial("tcp", address): Intenta conectarse al otro usuario en la dirección especificada.

	if err != nil {
		fmt.Println("Error connecting to peer:", err.Error())
		return
	} //Si hay un error, muestra el mensaje y la conexion termina

	defer conn.Close() //cierre de la conexion
	go receiveMessage(conn) // Recibe mensajes del otro usuario en un hilo separado.
	sendMessage(conn)// Envia un mensaje al otro usuario
}




func receiveMessage(conn net.Conn){ //recibe un mensaje de la conexion 
	defer conn.Close() //cierra la conexion automaticamente cuando termina la conexión
	reader := bufio.NewReader(conn) // leer datos desde la conexión
	message, _ := reader.ReadString('\n') /*
	lee datos hasta encontrar un salto de línea 
	Guarda el mensaje en la variable message.
	*/
	fmt.Print(message) //Imprime el mensaje recibido en la consola.

}

func sendMessage(conn net.Conn){//envia un mensaje a la conexión
	writer := bufio.NewWriter(conn)  //escribir datos 
	fmt.Println("Connected to peer.Type your message:")
	/*	Muestra un mensaje en la consola para indicar que está listo para enviar un mensaje.*/
	message := "this is the first message :)" //define un mensaje de prueba
	_, err := writer.WriteString(message)
	/*
	Escribe el mensaje en el buffer del escritor.
	writer.WriteString(message) devuelve el número de bytes escritos y un posible error (err).
	*/
	if err != nil {
		fmt.Println("Error sending message:", err.Error())
	
	}
	writer.Flush()// envía el mensaje a través de la conexión
}
