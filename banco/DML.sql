/*DML*/

USE fastrade

INSERT INTO Tipo_Usuario (Tipo) VALUES ('Consumidor');

INSERT INTO Tipo_Usuario (Tipo) VALUES ('Fornecedor');

INSERT INTO Endereco (Numero, Estado, Bairro, Rua, CEP) VALUES (67, 'SP', 'Jardim Madalena', 'Alfredo dos Andes', '12345678');

INSERT INTO Cat_Produto (Tipo) VALUES ('Conversa');

INSERT INTO Cat_Produto (Tipo) VALUES ('Bebidas');

INSERT INTO Produto (Id_Cat_Produto, Nome, Validade) VALUES  (1, 'Feijão', '22/11/2022'); 

INSERT INTO Receita (Nome) VALUES ('Limão');

INSERT INTO Receita (Nome) VALUES ('Casca de Laranja');

INSERT INTO Produto_Receita (Id_Produto, Id_Receita) VALUES (1, 2)

INSERT INTO Usuario (Id_Endereco, Id_Tipo_Usuario, Nome_Razao_Social, Email, Senha, Celular, CPF_CNPJ) VALUES (1, 1, 'Barraca do Chiquinho', 'Barraca@Live.com', '******', '(11)9777-6666', '12345678912345' );

INSERT INTO Pedido (Id_Produto, Id_Usuario, Quantidade) VALUES (1, 1, 20);

INSERT INTO Oferta (Id_Produto, Id_Usuario, Quantidade, Preco, Foto_Url) VALUES (1, 1, 50, '4,99', 'Url_Imagens_Texto');


