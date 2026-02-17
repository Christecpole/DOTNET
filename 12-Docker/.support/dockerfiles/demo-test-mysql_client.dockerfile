# On part d'une image d'Ubuntu
FROM ubuntu:latest

# On demande la mise à jour des paquets
RUN apt update -y 

# On demande l'installation du client MySQL
RUN apt install -y mysql-client 

# Pour copier un fichier et le placer dans l'image finale, on utilise COPY ou ADD
COPY ./test.txt /tmp/test.txt
# ADD ./test.txt /tmp/test.txt

# On choisi la commande de lancement du conteneur via l'instruction CMD
CMD ["/bin/bash"]
