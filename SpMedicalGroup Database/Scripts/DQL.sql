SELECT * FROM USUARIOS
SELECT * FROM CREDENCIAIS
SELECT * FROM CLINICAS
SELECT * FROM ESPECIALIDADES
SELECT * FROM MEDICOS
SELECT * FROM PACIENTES
SELECT * FROM STATUS_CONSULTA
SELECT * FROM CONSULTAS

--Mostrou a quantidade de usu�rios ap�s realizar a importa��o do banco de dados
SELECT COUNT (ID) AS Quantidade_su�rios
FROM USUARIOS;

--Converteu a data de nascimento do usu�rio para o formato 
SELECT convert(varchar, getdate(), 101)	 DATA_NASCIMENTO FROM PACIENTES

SELECT EMAIL, CREDENCIAL FROM USUARIOS INNER JOIN CREDENCIAIS ON USUARIOS.ID_CREDENCIAL = CREDENCIAIS.ID