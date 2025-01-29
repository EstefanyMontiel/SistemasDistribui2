package main

import (
	"os"

	"github.com/EstefanyMontiel/p2p_chat/internal/peer"
)

func main(){

	operation  := os.Args[1]
	connection := os.Args[2]
	username := os.Args[3]
	
	if operation == "connect"{
		peer.ConnectToPeer(connection,username)	
	} else {
		peer.StarListening(connection,username)
	}
}
