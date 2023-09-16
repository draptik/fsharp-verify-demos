module MyDemo.Lib

open System

type SimpleName = {
    FirstName: string
    LastName: string
}

type SimpleNameOption = {
    FirstName: string option
    LastName: string
}

type CreditCard = {
    CardNumber: string
    ExpiryDate: DateTime
}

type Cash = {
    Amount: decimal
}

type PaymentMethod =
    | CreditCard of CreditCard
    | Cash of Cash
