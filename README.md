##Para executar o projeto

Olá,

Antes de executar a aplicação completa, será necessário fazer 2 passos!

1° Criar o banco de dados MySql

A aplicação utiliza o Mysql como banco de dados.
Junto dos arquivos desse sistema, na pasta BD logo no ínicio tem o arquivo script_bd.txt ou script_jab.sql, basta copiar o conteúdo dele, executar no mysql, e o banco de dados estará criado.

2° Com o banco de dados criado no Mysql, é necessário alterar uma única linha de código para que a conexão de dados funcione.

Para isso, basta ir na classe PersistenciaDados.cs,e logo no início do código, há uma linha na qual a constante String de conexão é definida. Então é preciso
ajustar as informações de acordo com as informações do banco de dados local da máquina.

Exemplo abaixo:

private const String strConexao = "server=localhost;port=3306;UID=root;database=crudjab;pwd=;";
                                   
Parametros da conexão
server= id do servidor mysql.
port= porta de comunicação que o mysql executa localmente
UID=nome do usuário do mysql
database=nome do banco de dados
pwd=senha do mysql

Após a strConexao ser devidadamente preenchida, basta executar o programa.
