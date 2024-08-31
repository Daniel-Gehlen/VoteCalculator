# Technical Report: Windows Forms Vote Calculator Application

## 1. Introduction

This project is a Windows Forms application developed in C# that allows for the calculation and storage of vote results based on three input weights (A, B, and C). The application validates user inputs, displays real-time round results, and saves the round history to a JSON file. The project was created to demonstrate basic concepts in graphical interface development, data manipulation, and file persistence.

## 2. Objectives

The primary objectives of this project are to:
- Calculate votes based on user-defined weights.
- Record the history of rounds, including the number of approvals and rejections.
- Validate user inputs to ensure only allowed values (0 or 1) are accepted.
- Save the round history to a JSON file for future reference.

## 3. Code Structure

### 3.1. Graphical Interface

The graphical interface of the application was built using Windows Forms. The interface includes the following main components:
- **Labels**: Display information such as the header, explanations, round results, total approvals, total rejections, and the number of rounds.
- **TextBoxes**: Allow the user to enter values for A, B, and C.
- **Buttons**: Three main buttons perform the functions of calculating results, resetting the application, and saving the history.
- **ListBox**: Displays the history of rounds with their respective results and timestamps.

### 3.2. Features

- **Vote Calculation**: The `BtnCalcular_Click` function performs input validation and calculates whether the combination of weights results in approval or rejection. If the input values are valid (0 or 1), the result is displayed and the history is updated.
- **Input Validation**: To ensure that users enter only permitted values, the application uses the `txt_KeyPress` function to intercept any invalid input and alerts the user to correct the value.
- **Saving History**: The `BtnSalvar_Click` function allows the history of rounds to be saved to a JSON file. This includes the total number of approvals, rejections, and a list of rounds with timestamps.
- **Resetting the Application**: The `BtnReiniciar_Click` function resets all variables and clears the history, allowing the user to start a new series of calculations.

### 3.3. JSON Structure

The round history is saved in a JSON file with the following structure:

```json
{
    "Rodadas": [
        "Round 1 - 2024-08-31 12:00:00: Approved: A=1, B=1, C=1",
        "Round 2 - 2024-08-31 12:05:00: Rejected: A=1, B=0, C=0"
    ],
    "TotalAprovacoes": 1,
    "TotalReprovacoes": 1
}
```

## 4. Results

The project has met its initial objectives by providing an intuitive interface for vote calculation and data storage. The input validation and JSON saving functionalities add robustness to the application, making it useful in scenarios where decision records are needed.

## 5. Conclusion

This project serves as a solid foundation for developing more complex Windows Forms applications, with potential for expansion to include additional functionalities such as data visualization, database integration, or more complex voting logic. The application successfully demonstrates fundamental programming and graphical interface concepts in C#, while also ensuring data persistence through JSON files.

## 6. Future Improvements

Some improvements that could be implemented in future versions include:
- **Data Export**: Adding the option to export round history to other formats, such as CSV or Excel.
- **Statistical Analysis**: Implementing statistical analysis of results, such as percentages of approval and rejection.
- **Enhanced Interface**: Improving the graphical interface with custom themes and better responsiveness.

---

# Relatório Técnico: Aplicação Windows Forms para Cálculo de Votos

## 1. Introdução

Este projeto é uma aplicação Windows Forms desenvolvida em C# que permite o cálculo e armazenamento de resultados de votos com base em três pesos de entrada (A, B e C). A aplicação valida as entradas dos usuários, exibe os resultados das rodadas em tempo real, e salva o histórico das rodadas em um arquivo JSON. O projeto foi criado para demonstrar conceitos básicos de desenvolvimento de interfaces gráficas, manipulação de dados e persistência de informações em arquivos.

## 2. Objetivos

O principal objetivo deste projeto é desenvolver uma aplicação de fácil utilização que permita:
- Calcular votos com base em pesos definidos pelo usuário.
- Registrar o histórico das rodadas, incluindo o número de aprovações e reprovações.
- Validar as entradas dos usuários para garantir que apenas valores permitidos (0 ou 1) sejam aceitos.
- Salvar o histórico das rodadas em um arquivo JSON para futura referência.

## 3. Estrutura do Código

### 3.1. Interface Gráfica

A interface gráfica da aplicação foi construída utilizando o Windows Forms. A interface possui os seguintes componentes principais:
- **Labels**: Exibem informações como o cabeçalho, explicações, resultados das rodadas, total de aprovações, total de reprovações e o número de rodadas.
- **TextBoxes**: Permitem que o usuário insira os valores de A, B e C.
- **Buttons**: Três botões principais que executam as funções de calcular os resultados, reiniciar a aplicação, e salvar o histórico.
- **ListBox**: Exibe o histórico das rodadas com seus respectivos resultados e timestamps.

### 3.2. Funcionalidades

- **Cálculo de Votos**: A função `BtnCalcular_Click` realiza a validação das entradas e calcula se a combinação dos pesos resulta em uma aprovação ou reprovação. Se os valores de entrada são válidos (0 ou 1), o resultado é exibido, e o histórico é atualizado.
- **Validação de Entradas**: Para garantir que os usuários insiram apenas valores permitidos, a aplicação utiliza a função `txt_KeyPress` para interceptar qualquer entrada inválida e alerta o usuário para corrigir o valor.
- **Salvamento do Histórico**: A função `BtnSalvar_Click` permite que o histórico das rodadas seja salvo em um arquivo JSON. Isso inclui o número total de aprovações, reprovações, e uma lista das rodadas com timestamps.
- **Reinício da Aplicação**: A função `BtnReiniciar_Click` reinicia todas as variáveis e limpa o histórico, permitindo que o usuário comece uma nova série de cálculos.

### 3.3. Estrutura do JSON

O histórico das rodadas é salvo em um arquivo JSON com a seguinte estrutura:

```json
{
    "Rodadas": [
        "Rodada 1 - 2024-08-31 12:00:00: Aprovado: A=1, B=1, C=1",
        "Rodada 2 - 2024-08-31 12:05:00: Reprovado: A=1, B=0, C=0"
    ],
    "TotalAprovacoes": 1,
    "TotalReprovacoes": 1
}
```

## 4. Resultados

O projeto alcançou seus objetivos iniciais, proporcionando uma interface intuitiva para o cálculo de votos e o armazenamento de resultados. As funcionalidades de validação de entradas e salvamento em JSON adicionam robustez à aplicação, tornando-a útil em diversos cenários onde o registro de decisões é necessário.

## 5. Conclusão

Este projeto serve como uma excelente base para o desenvolvimento de aplicações Windows Forms mais complexas, com potencial para ser expandido com funcionalidades adicionais, como a inclusão de gráficos, integração com bancos de dados, ou a aplicação de lógica mais complexa para o cálculo de votos. A aplicação demonstra com sucesso o uso de conceitos fundamentais de programação e interface gráfica em C#, ao mesmo tempo que garante a persistência dos dados através de arquivos JSON.

## 6. Futuras Melhorias

Algumas melhorias que podem ser implementadas em versões futuras incluem:
- **Exportação de Dados**: Adicionar a opção de exportar o histórico das rodadas para outros formatos, como CSV ou Excel.
- **Análise Estatística**: Implementar uma análise estatística dos resultados, como porcentagens de aprovação e reprovação.
- **Interface Melhorada**: Melhorar a interface gráfica com temas personalizados e maior responsividade.
