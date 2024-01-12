# Jeopardy.API

## Overview
 This API provides endpoints to retrieve information about Jeopardy game categories and clues. Below is a guide on how to use these endpoints to integrate the API into your project.

All information were scraped from [J-Archive](https://www.j-archive.com/).

> Please note this project is still under development.

## API Endpoints

Base URL: https://jeopardy-api.azurewebsites.net/

### 1. Get Categories
#### Endpoint: `/api/categories`
- **Method:** GET
- **Parameters:**
  - `SearchTerm` (optional): Search term for filtering categories.
  - `PageNumber` (optional): Page number for pagination (integer).
  - `PageSize` (optional): Page size for pagination (integer).
  - `OrderBy` (optional): Sorting order for categories (string).
  - `Randomize` (optional): Boolean flag to randomize results.

- **Response:**
  - HTTP 200 OK
  - Content types: `text/plain`, `application/json`, `text/json`
  - Body: Array of CategoryDto objects.

### 2. Get Category by ID
#### Endpoint: `/api/categories/{id}`
- **Method:** GET
- **Parameters:**
  - `id` (required): ID of the category (integer).

- **Response:**
  - HTTP 200 OK
  - Content types: `text/plain`, `application/json`, `text/json`
  - Body: CategoryDto object.

### 3. Get Random Clue from Category
#### Endpoint: `/api/categories/{id}/random`
- **Method:** GET
- **Parameters:**
  - `id` (required): ID of the category (integer).
  - `Round` (optional): Round number (integer).
  - `Value` (optional): Clue value (integer).
  - `Category` (optional): Category ID (integer).
  - `PageNumber` (optional): Page number for pagination (integer).
  - `PageSize` (optional): Page size for pagination (integer).
  - `OrderBy` (optional): Sorting order for clues (string).
  - `Randomize` (optional): Boolean flag to randomize results.

- **Response:**
  - HTTP 200 OK
  - Content types: `text/plain`, `application/json`, `text/json`
  - Body: ClueDto object.

### 4. Get Clues
#### Endpoint: `/api/clues`
- **Method:** GET
- **Parameters:**
  - `SearchTerm` (optional): Search term for filtering clues.
  - `PageNumber` (optional): Page number for pagination (integer).
  - `PageSize` (optional): Page size for pagination (integer).
  - `OrderBy` (optional): Sorting order for clues (string).
  - `Randomize` (optional): Boolean flag to randomize results.

- **Response:**
  - HTTP 200 OK
  - Content types: `text/plain`, `application/json`, `text/json`
  - Body: Array of ClueDto objects.

### 5. Get Clue by ID
#### Endpoint: `/api/clues/{id}`
- **Method:** GET
- **Parameters:**
  - `id` (required): ID of the clue (integer).

- **Response:**
  - HTTP 200 OK
  - Content types: `text/plain`, `application/json`, `text/json`
  - Body: ClueDto object.

## Data Models

### CategoryResponse
```json
{
  "id": 1,
  "name": "Category Name"
}
```

### ClueResponse
```json
{
  "id": 1,
  "game": 1,
  "round": 1,
  "value": 200,
  "clue": "Clue Text",
  "answer": "Answer Text",
  "airDate": "2024-01-12",
  "categories": [
    {
      "id": 1,
      "name": "Category Name"
    }
  ]
}
```
