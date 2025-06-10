# Objetivo
Um console application apenas para exemplificar o envio de um produto, serializado, para fila do RabbitMQ e para consumir da fila, exibindo em tela.

Disponibilizado uma interface, onde é possível decidir ser um Producer ou Consumer.

# Execução do ambiente
É mandatório ter o kafka rodando na porta 5672 ou roder o comando `docker compose up`, na pasta onde o arquivo docker-compose.yml está presente.

Assim a máquina subirá um servidor RabbitMQ na porta 5672 e você poderá acessar o admin em http://localhost:15672/ com usuário **guest** e senha **guest**.

Divirta-se!!
