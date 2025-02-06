package main

import (
	"fmt"
	"github/EstefanyMontiel/p2pfileshare/internal/peer"
	"os"
)

func main() {
	done := make(chan struct{})
	go func() {
		defer close(done)
		peer.StartListening(os.Args[2])
	}()

	if os.Args[1] == "download" {
		peer.DownloadFile(os.Args[3], os.Args[4], os.Args[5])
	} else {
		fmt.Println("waitinf for connections...")
	}
	<-done

}
