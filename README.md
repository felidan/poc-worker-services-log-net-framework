POC de Windows Services com .Net Framework
===================================================

## Configuração do instalador
* No Design do serviço -> clicar com o botão direito -> Add Installer 
* Nas propriedades do arquivo serviceProcessInstaller: alterar a propriedade 'Account' para 'LocalSystem'
* Nas propriedades do arquivo serviceInstaller: alterar a propriedade 'ServiceName' para 'NOME_DO_SEU_SERVICO'

## Instalação do serviço no windows
* Executar o CMD do Visual Studio como Administrador.
* Executar o comando: installutil CAMINHO_DO_EXE

## Desinstalar o serviço: 
* Executar o CMD do Visual Studio como Administrador.
* Executar o comando: installutil /u CAMINHO_DO_EXE