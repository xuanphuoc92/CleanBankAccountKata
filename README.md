# Bank Account Kata: Uncle Bob's Clean Architecture version

I have known Uncle Bob's Clean Architecture model for awhile, but did not understand it thoroughly and know how to apply it. And since I find katas as one of the most effective ways in learning code, then why not try having a kata that can help learn the Clean Architecture model?

So I choose the Bank Account kata for this little experiment. You can find a version of Bank Account kata from [Sandro Macuso](https://github.com/sandromancuso/Bank-kata), which focuses on learning rules of Object Calisthenic. For this kata, I think the focus is more on Clean Architecture model from [Uncle Bob](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html), specifically based on this model from his book: 

![typical clean architecture model](https://i.stack.imgur.com/K44FQ.jpg)

<i>[Image source and discussion](https://softwareengineering.stackexchange.com/questions/380251/clean-architecture-what-is-the-view-model)</i>

I have to admit, this kata and my solution here may not be perfect, since this is also the first time I attempted it. So if you feel there is any room for improvement, don't hesitate to comment and let me know. In fact, after completing it first time and reading some discussions, I removed some wrong and unnecessary constraints for the instructions below; though, you may still find such constraints within the solution I committed. I also have to admit the boundary and data classes in a few last steps can be a bit overkill and their recommended design is likely not be correct. However, I think being overkill a bit should be part of a kata to provide a good learning experience.

## Prerequisite

If you are new to katas, consider trying out the [Ardalis's String Calculator](https://www.youtube.com/watch?v=H96nnZuQO00) and [Sandro Macuso's Bank kata](https://github.com/sandromancuso/Bank-kata) first.

## Instructions

Implement the classes and functions below using TDD as much as possible (if not always) with the recommended public properties and methods. Feel free to consider renaming, changing definitions, or adding properties and methods as you see fit along the way. If there is no recommended constructor, it is assumed that the class has a no-parameter constructor.

1. Create 5 zones (possibly using C# namespaces or Java packages) to control the boundary of the architecture:

- Entities
- Interactors
- DataInterfaces
- Frontend
- Backend

2. Implement `Account` class in Entities

```
+ Id: int = 0
+ Balance: decimal = 0
```

3. Implement `AccountDeposit` class in Interactors

```
+ AccountDeposit(Account)
+ Deposit(decimal): void
```

`Deposit(decimal)` method will increase the Balance of the account by the amount in the parameter.

4. Implement `AccountWithdraw` class in Interactors

```
+ AccountWithdraw(Account)
+ Withdraw(decimal): void
```

`Withdraw(decimal)` method will decrease the Balance of the account by the amount in the parameter.

5. Implement `Transaction` class in Entities

```
+ Account: Account = null
+ Amount: decimal = 0
+ Balance: decimal = 0
+ Date: DateTime = Today
```

6. Change `Account` class to contains:

```
+ Transactions: List<Transaction> = empty list
```

7. Change `AccountDeposit` and `AccountWithdraw` classes such that when they deposit and withdraw for an account, a transaction is created each time, whose Amount is negative for withdrawal and Balance is the balance of the account after the transaction.

8. *TDD Reminder:* Check for any duplication and refactor.

9. Implement `AccountTransfer` class in Interactors

```
+ AccountTransfer(Account)
+ Transfer(decimal, Account): void
```

`Transfer(decimal, Account)` method will transfer the amount from the account in constructor to the account in the method's parameters. You may consider using AccountDeposit and AccountWithdraw interactors, and apply the same changes 

10. Implement `AccountContext` in the DataInterfaces

```
+ Count(): int
+ Save(Account): void
+ Load(int): Account
```

`Save(Account)` will save the account in the parameter into a data storage or database (recommended to be a `Dictionary<int, Account>`). If the account's Id is 0, the account's Id should change to `Count() + 1` before storing into the data storage.

`Load(int)` will load the account with the Id in the parameter. If there is no such Id, return null.

`Count()` returns the number of account stored in the data storage so far. You may consider having `Count()` method replaced with get-only property `+ Count: int = 0`.

11. Refactor/extract the functions of `AccountContext` into a class named `MemoryDataAccess`. `AccountContext` then uses the functions from a `MemoryDataAccess` instance.

12. Refactor the `MemoryDataAccess` into a generic class `MemoryDataAccess<TObject, TKey>`. The instance used in `AccountContext` should be of type `MemoryDataAccess<Account, int>`. Recommendation: create a field `Func<TObject, TKey>` for the `MemoryDataAccess<TObject, TKey>` to make the generic form possible.

13. Refactor/extract interface `IDataAccess<TObject, TKey>` from `MemoryDataAccess<TObject, TKey>`, and replace the field in `AccountContext` from `MemoryDataAccess<Account, int>` to `IDataAccess<Account, int>`.

14. Implement an additional parameter `date` for methods `AccountDeposit`, `AccountWithdraw`, and `AccountTransfer` for them to mock different dates of transactions.

15. Implement `StatementInputData` class in Interactors

```
+ AccountId: int
```

16. Implement `StatementOutputData` class in Interactors

```
+ AccountId: int
+ LineItems: List<LineItem>
```

`LineItem` class can be a public internal class of `StatementOutputData`:

```
+ Date: DateTime
+ Credit: decimal?
+ Debit: decimal?
+ Balance: decimal
```

17. Implement `StatementInputBoundary` and `StatementOutputBoundary` interfaces in Interactors

18. Implement `Statement` class in Interactors, and `StringStatementController` and `StringStatementPresenter` classes in Frontend. The implementation should use the 4 boundaries and data structures in previous steps: `StatementInputData`, `StatementOutputData`, `StatementInputBoundary`, and `StatementOutputBoundary`. Particularly, the `Statement` class must be implementing from `StatementInputBoundary`, and the `StringStatementPresenter` must be implementing from `StatementOutputBoundary`. At the end, `StringStatementPresenter` should have the following method:

```
+ Print(): string
```

`Print()` should create a output string as following sample below:

```
Account: 1
Date || Credit || Debit || Balance
20/01/2022 || 100.00 ||  || 100.00
21/01/2022 ||  || 20.00 || 80.00
```

19. Review and refactor, if possible, so that the following constraints can be enforced:

- No reference of any zone in Entities zone
- No reference of Frontend and Backend in Entities, Interactors, and DataInterfaces zones .If `MemoryDataAccess` is moved to Backend zone, it can be an exception as the default data access. However, all other implementations of `IDataAccess` in the future (e.g. `LogFileDataAccess`, `SQLDataAccess`, `MongoDbDataAccess`, etc.) should stay in Backend zone. At this point, there is no further implementations of `IDataAccess` in this kata, but it is very likely they may appear in the future katas from this one.
- No reference of **DataInterfaces and Backend** in **Interactors and Frontend**.
