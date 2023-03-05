Feature: Purchase a product
As a user of the website
I want to purchase a product 

Scenario: Add a product to the cart
    Given I am on the SauceDemo login page
   When I log in with valid credentials
   Then I should be redirected to the SauceDemo products page
   When I add a product to my cart
    Then product should be added to the cart successfully 

Scenario: View cart and checkout
    Given I am on the SauceDemo login page
   When I log in with valid credentials
   Then I should be redirected to the SauceDemo products page
   When I add a product to my cart
   And I go to the cart page
   And I click on the checkout button
   Then I should be on the SauceDemo checkout information page 

Scenario: Enter shipping information
    Given I am on the SauceDemo login page
   When I log in with valid credentials
   Then I should be redirected to the SauceDemo products page
   When I add a product to my cart
   And I go to the cart page
   And I click on the checkout button
   Then I should be on the SauceDemo checkout information page
   When I enter my personal and payment information
   And I click on the continue button
   Then I should be on the SauceDemo checkout overview page  

Scenario: Add product to cart and checkout successfully
   Given I am on the SauceDemo login page
   When I log in with valid credentials
   Then I should be redirected to the SauceDemo products page
   When I add a product to my cart
   And I go to the cart page
   And I click on the checkout button
   Then I should be on the SauceDemo checkout information page
   When I enter my personal and payment information
   And I click on the continue button
   Then I should be on the SauceDemo checkout overview page
   And I should see the product I added to my cart
   When I click on the finish button
   Then I should be on the SauceDemo checkout complete page

Scenario: Add Multiple Products
   Given I am on the SauceDemo login page
   When I log in with valid credentials
   Then I should be redirected to the SauceDemo products page
   When I add multiple products to my cart
   And I go to the cart page
   And I click on the checkout button
   Then I should be on the SauceDemo checkout information page
   When I enter my personal and payment information
   And I click on the continue button
   Then I should be on the SauceDemo checkout overview page
   And I should see the product I added to my cart
   When I click on the finish button
   Then I should be on the SauceDemo checkout complete page