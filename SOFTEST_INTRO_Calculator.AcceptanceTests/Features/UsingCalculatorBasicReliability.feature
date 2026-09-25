@BasicMusa
Feature: UsingCalculatorBasicReliability
    In order to calculate the Basic Musa model's failures and intensities
    As a Software Quality Metric enthusiast
    I want to use my calculator to do this

    Scenario: Calculate current failure intensity
        Given I have a calculator
        And the initial failure intensity is 10
        And the expected total number of failures is 100
        And the accumulated execution time is 5 hours
        When I calculate the current failure intensity
        Then the result should be 6.065306597126334

    Scenario: Calculate current failure intensity at zero execution time
        Given I have a calculator
        And the initial failure intensity is 10
        And the expected total number of failures is 100
        And the accumulated execution time is 0 hours
        When I calculate the current failure intensity
        Then the result should be 10

    Scenario: Calculate expected cumulative failures
        Given I have a calculator
        And the initial failure intensity is 10
        And the expected total number of failures is 100
        And the accumulated execution time is 5 hours
        When I calculate the expected cumulative failures
        Then the result should be 39.346934028736655