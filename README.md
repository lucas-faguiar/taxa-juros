# Calcula Juros

Este projeto consiste em duas APIs utilizadas para calcular o valor de juros compostos independente de moeda.

## API Taxa Juros

A primeira API contém apenas um serviço que retorna uma taxa de juros fixa: 0,01.

### Serviço: obter taxa de juros

Retorna taxa de juros fixa.

```
GET /taxajuros
```

## API Calcula Juros

A segunda API contém dois serviços que são usados para o cálculo do juros composto e obtenção de informações.

### Serviço: calcular juros

Calcula o valor de juros composto a partir do valor inicial do capital, da quantidade de meses que o capital ficará aplciado. A taxa de juros é obtida da API Taxa de juros.

```
GET /calculaJuros?valorInicial={valorInicial}&meses={qunatidadeMeses}
```
### Serviço: show me the code

Retorna a url onde o código fonte do projeto pode ser encontrado

```
GET /showmethecode
```

## Implantação

Ambas as APIs fazem uso do swagger e estão implantadas na plataforma de IaaS Microsoft Azure 

API Taxa Juros

```
https://taxajuros.azurewebsites.net/
```

API Calcula Juros

```
https://calculajuros.azurewebsites.net/
```

## Testes

Foram desenvolvidos tetes unitátios e de integração na API Calcula Juros.

### Executando os testes

Para executar os testes basta acessar o diretório de testes do projeto e executar o comando:

```
dotnet test
```

Você deverá ver uma resposta semelhante a esta:

```
Microsoft (R) Test Execution Command Line Tool Version 16.6.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...

A total of 1 test files matched the specified pattern.

Test Run Successful.
Total tests: 4
     Passed: 4
 Total time: 26,6942 Seconds
```

## Tecnologia

* dotnet core 3.1

## Autor

* **Lucas Aguiar**
