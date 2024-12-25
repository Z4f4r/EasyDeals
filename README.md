# City API Documentation

## Overview

The `CityRepository` serves as the data access layer for managing city records in the database. This layer handles the following:

- CRUD operations for cities
- Querying with filtering, sorting, and pagination
- Logical deletion via the `IsActive` property

The `CityController` utilizes this repository to expose API endpoints for client interaction.

---

## Repository Logic

### Entity Model: `City`

```csharp
public class City
{
    private int id;

    private string title = string.Empty;

    private bool isActive = true;

    private DateTime createdAt = DateTime.Now.ToUniversalTime();

    private DateTime updatedAt = DateTime.Now.ToUniversalTime();

    private List<Product> products = [];



    public int Id { get => id; set => id = value; }

    public string Title { get => title; set => title = value; }

    public bool IsActive { get => isActive; set => isActive = value; }

    public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

    public DateTime UpdatedAt { get => updatedAt; set => updatedAt = value; }

    public List<Product> Products { get => products; set => products = value; }
}
```

### Repository Methods

#### 1. **CreateAsync**

- **Description:** Adds a new city to the database and returns the created entity.
- **Input:** `City` entity.
- **Output:** `City?`
- **Integration:** Used in the `POST /api/City` endpoint.

---

#### 2. **GetAllAsync**

- **Description:** Retrieves a paginated list of active cities, with optional filtering and sorting.
- **Input:**
  - `CityQueryObject`:
    ```csharp
    public class CityQueryObject
    {
        private string title = string.Empty;

        private string? sortBy;

        private bool isDescending = false;

        public int pageNumber = 1;

        public int pageSize = 20;



        public string Title { get => title; set => title = value; }

        public string? SortBy { get => sortBy; set => sortBy = value; }

        public bool IsDescending { get => isDescending; set => isDescending = value; }

        public int PageNumber { get => pageNumber; set => pageNumber = value; }

        public int PageSize { get => pageSize; set => pageSize = value; }
    }
    ```
- **Output:** `List<City>?`
- **Integration:** Used in the `GET /api/City` endpoint.

---

#### 3. **GetByIdAsync**

- **Description:** Retrieves a single city by ID if it is active.
- **Input:** `int id`
- **Output:** `City?`
- **Integration:** Used in the `GET /api/City/{id}` endpoint.

---

#### 4. **UpdateAsync**

- **Description:** Updates the fields of an existing city by ID if it is active.
- **Input:**
  - `int id`
  - `UpdateCityDTO`:
    ```csharp
    public class UpdateCityDTO
    {
        private string title = string.Empty;

        private bool isActive = true;



        [Required]
        [MinLength(5, ErrorMessage = "Title must be 5 characters")]
        [MaxLength(25, ErrorMessage = "Title cannot be over 25 characters")]
        public string Title { get => title; set => title = value; }

        [Required]
        public bool IsActive { get => isActive; set => isActive = value; }
    }
    ```
- **Output:** `City?`
- **Integration:** Used in the `PUT /api/City/{id}` endpoint.

---

#### 5. **DeleteAsync**

- **Description:** Marks a city as inactive (soft delete) by setting `IsActive` to `false`.
- **Input:** `int id`
- **Output:** `City?`
- **Integration:** Used in the `DELETE /api/City/{id}` endpoint.

---

## API Endpoints and Behavior

### 1. **Get All Cities**

- **Repository Method:** `GetAllAsync`
- **Controller Endpoint:** `GET /api/City`
- **Features:**
  - **Filtering:** By `Title`.
  - **Sorting:** By `Title`, `CreatedAt`, or `UpdatedAt` (ascending/descending).
  - **Pagination:** Controlled by `PageNumber` and `PageSize`.

---

### 2. **Get City by ID**

- **Repository Method:** `GetByIdAsync`
- **Controller Endpoint:** `GET /api/City/{id}`
- **Behavior:**
  - Returns the city if `IsActive = true`.
  - Returns `404 Not Found` if the city does not exist or is inactive.

---

### 3. **Create a City**

- **Repository Method:** `CreateAsync`
- **Controller Endpoint:** `POST /api/City`
- **Behavior:**
  - Adds a new city to the database.
  - Returns `201 Created` with the location of the created city.

---

### 4. **Update a City**

- **Repository Method:** `UpdateAsync`
- **Controller Endpoint:** `PUT /api/City/{id}`
- **Behavior:**
  - Updates fields of an active city.
  - Returns `404 Not Found` if the city does not exist or is inactive.
  - Returns `200 OK` with the updated city details.

---

### 5. **Delete a City**

- **Repository Method:** `DeleteAsync`
- **Controller Endpoint:** `DELETE /api/City/{id}`
- **Behavior:**
  - Marks the city as inactive (`IsActive = false`).
  - Returns `204 No Content` if successful.
  - Returns `404 Not Found` if the city does not exist or is already inactive.

---

## Error Handling

All API errors follow this format:

```json
{
  "status": "error",
  "message": "Error description"
}
```

---

## Querying Cities

You can combine filters, sorting, and pagination to retrieve data efficiently.

---



# State API Documentation

## Overview

The `StateRepository` serves as the data access layer for managing state records in the database. This layer handles the following:

- CRUD operations for states
- Querying with filtering, sorting, and pagination
- Logical deletion via the `IsActive` property

The `StateController` utilizes this repository to expose API endpoints for client interaction.

---

## Repository Logic

### Entity Model: `State`

```csharp
public class State
{
    private int id;

    private string title = string.Empty;

    private bool isActive = true;

    private DateTime createdAt = DateTime.Now.ToUniversalTime();

    private DateTime updatedAt = DateTime.Now.ToUniversalTime();

    private List<Product> products = [];



    public int Id { get => id; set => id = value; }

    public string Title { get => title; set => title = value; }

    public bool IsActive { get => isActive; set => isActive = value; }

    public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

    public DateTime UpdatedAt { get => updatedAt; set => updatedAt = value; }

    public List<Product> Products { get => products; set => products = value; }
}
```

### Repository Methods

#### 1. **CreateAsync**

- **Description:** Adds a new state to the database and returns the created entity.
- **Input:** `State` entity.
- **Output:** `State?`
- **Integration:** Used in the `POST /api/State` endpoint.

---

#### 2. **GetAllAsync**

- **Description:** Retrieves a paginated list of active states, with optional filtering and sorting.
- **Input:**
  - `StateQueryObject`:
    ```csharp
    public class StateQueryObject
    {
        private string title = string.Empty;

        private string? sortBy;

        private bool isDescending = false;

        public int pageNumber = 1;

        public int pageSize = 20;



        public string Title { get => title; set => title = value; }

        public string? SortBy { get => sortBy; set => sortBy = value; }

        public bool IsDescending { get => isDescending; set => isDescending = value; }

        public int PageNumber { get => pageNumber; set => pageNumber = value; }

        public int PageSize { get => pageSize; set => pageSize = value; }
    }
    ```
- **Output:** `List<State>?`
- **Integration:** Used in the `GET /api/State` endpoint.

---

#### 3. **GetByIdAsync**

- **Description:** Retrieves a single state by ID if it is active.
- **Input:** `int id`
- **Output:** `State?`
- **Integration:** Used in the `GET /api/State/{id}` endpoint.

---

#### 4. **UpdateAsync**

- **Description:** Updates the fields of an existing state by ID if it is active.
- **Input:**
  - `int id`
  - `UpdateStateDTO`:
    ```csharp
    public class UpdateStateDTO
    {
        private string title = string.Empty;

        private bool isActive = true;



        [Required]
        [MinLength(5, ErrorMessage = "Title must be 5 characters")]
        [MaxLength(25, ErrorMessage = "Title cannot be over 25 characters")]
        public string Title { get => title; set => title = value; }

        [Required]
        public bool IsActive { get => isActive; set => isActive = value; }
    }
    ```
- **Output:** `State?`
- **Integration:** Used in the `PUT /api/State/{id}` endpoint.

---

#### 5. **DeleteAsync**

- **Description:** Marks a state as inactive (soft delete) by setting `IsActive` to `false`.
- **Input:** `int id`
- **Output:** `State?`
- **Integration:** Used in the `DELETE /api/State/{id}` endpoint.

---

## API Endpoints and Behavior

### 1. **Get All States**

- **Repository Method:** `GetAllAsync`
- **Controller Endpoint:** `GET /api/State`
- **Features:**
  - **Filtering:** By `Title`.
  - **Sorting:** By `Title`, `CreatedAt`, or `UpdatedAt` (ascending/descending).
  - **Pagination:** Controlled by `PageNumber` and `PageSize`.

---

### 2. **Get State by ID**

- **Repository Method:** `GetByIdAsync`
- **Controller Endpoint:** `GET /api/State/{id}`
- **Behavior:**
  - Returns the state if `IsActive = true`.
  - Returns `404 Not Found` if the state does not exist or is inactive.

---

### 3. **Create a State**

- **Repository Method:** `CreateAsync`
- **Controller Endpoint:** `POST /api/State`
- **Behavior:**
  - Adds a new state to the database.
  - Returns `201 Created` with the location of the created state.

---

### 4. **Update a State**

- **Repository Method:** `UpdateAsync`
- **Controller Endpoint:** `PUT /api/State/{id}`
- **Behavior:**
  - Updates fields of an active state.
  - Returns `404 Not Found` if the state does not exist or is inactive.
  - Returns `200 OK` with the updated state details.

---

### 5. **Delete a State**

- **Repository Method:** `DeleteAsync`
- **Controller Endpoint:** `DELETE /api/State/{id}`
- **Behavior:**
  - Marks the state as inactive (`IsActive = false`).
  - Returns `204 No Content` if successful.
  - Returns `404 Not Found` if the state does not exist or is already inactive.

---

## Error Handling

All API errors follow this format:

```json
{
  "status": "error",
  "message": "Error description"
}
```

---

## Querying States

You can combine filters, sorting, and pagination to retrieve data efficiently.

---
