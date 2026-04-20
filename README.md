# Gilded Rose Refactoring Kata

Hi and welcome to team Gilded Rose. As you know, we are a small inn with a
prime location in a prominent city ran by a friendly innkeeper named
Allison. We also buy and sell only the finest goods. Unfortunately, our
goods are constantly degrading in quality as they approach their sell by
date. We have a system in place that updates our inventory for us. It was
developed by a no-nonsense type named Leeroy, who has moved on to new
adventures. Your task is to add the new feature to our system so that we
can begin selling a new category of items. First an introduction to our
system:

- All items have a SellIn value which denotes the number of days we have
  to sell the item
- All items have a Quality value which denotes how valuable the item is
- At the end of each day our system lowers both values for every item

Pretty simple, right? Well this is where it gets interesting:

- Once the sell by date has passed, Quality degrades twice as fast
- The Quality of an item is never negative
- "Aged Brie" actually increases in Quality the older it gets
- The Quality of an item is never more than 50
- "Sulfuras", being a legendary item, never has to be sold or decreases
  in Quality
- "Backstage passes", like aged brie, increases in Quality as it's SellIn
  value approaches; Quality increases by 2 when there are 10 days or less
  and by 3 when there are 5 days or less but Quality drops to 0 after the
  concert

We have recently signed a supplier of conjured items. This requires an
update to our system:

- "Conjured" items degrade in Quality twice as fast as normal items

Feel free to make any changes to the UpdateQuality method and add any
new code as long as everything still works correctly. However, do not
alter the Item class or Items property as those belong to the goblin
in the corner who will insta-rage and one-shot you as he doesn't
believe in shared code ownership (you can make the UpdateQuality
method and Items property static if you like, we'll cover for you).

Just for clarification, an item can never have its Quality increase
above 50, however "Sulfuras" is a legendary item and as such its
Quality is 80 and it never alters.

## Getting Started

Clone the repository. Run `dotnet build` from console, followed by `dotnet test`. If you see
output similar to the following screenshot, you are ready to
start refactoring.

![alt text](images/build_output.png "Good Build Output")

## Who, What, Why?

Who: [@TerryHughes](https://twitter.com/TerryHughes), [@NotMyself](https://twitter.com/NotMyself)

What & Why: [Refactor This: The Gilded Rose Kata](http://iamnotmyself.com/2011/02/13/refactor-this-the-gilded-rose-kata/)

## License

MIT

## Suggested attribution

This work is by [@TerryHughes](https://twitter.com/TerryHughes), [@NotMyself](https://twitter.com/NotMyself)

The repository can be found at [https://github.com/NotMyself/GildedRose](https://github.com/NotMyself/GildedRose)

## Solution Overview (Sourav Madan)

### Overview

The legacy implementation relied on a single method with deeply nested conditional logic, making it difficult to read, maintain, and extend. The solution focuses on refactoring the code incrementally while preserving existing behaviour and improving overall design quality.

### Approach

**Characterization Testing**  
Unit tests were written first to capture the existing behaviour. This ensured that all refactoring steps could be validated without introducing regressions.

**Incremental Refactoring**  
The large `UpdateQuality` method was gradually simplified by breaking down logic into smaller steps and improving readability while keeping tests passing throughout the process.

**Strategy-Based Design**  
Conditional logic was replaced with a strategy-based approach. Each item type is handled by a dedicated updater:

- NormalItemUpdater
- AgedBrieUpdater
- BackstagePassUpdater
- SulfurasUpdater
- ConjuredItemUpdater

This allows clear separation of responsibilities and makes the system easier to extend.

### Conjured Item Support

A new updater was introduced for Conjured items with the following rules:

- Quality degrades twice as fast as normal items
- Before sell date: decreases by 2
- After sell date: decreases by 4
- Quality never drops below 0

This was implemented without modifying existing behaviour.

### Defensive Programming

A null guard was added in the service constructor to prevent invalid input and ensure safer usage.

### Testing

- 26 unit tests implemented using xUnit
- Arrange–Act–Assert structure followed
- Covers all item types and edge cases
- All tests are passing

### Design Principles

- Single Responsibility: Each updater handles one item type
- Open/Closed: New items can be added without modifying existing logic
- Encapsulation: Business rules are isolated per updater
- Strategy Pattern: Behaviour is delegated instead of using conditionals

## Development Approach

The solution was developed incrementally using small commits. Each change was made in isolation and validated using tests to avoid regressions.

The commit history reflects the progression from characterization tests to refactoring, feature addition, and final polish.

---

### How to Run

Run the application:

dotnet run --project src/GildedRose.Console

Run tests:

dotnet test

### Summary

The system has been refactored to improve readability, maintainability, and extensibility while preserving existing behaviour. The introduction of a strategy-based design makes it easier to add new item types and reduces complexity compared to the original implementation.
This approach ensures the system remains easy to extend while maintaining confidence through test coverage.
