// Base URL for the People API
const peopleBaseUrl = 'http://wildoasis.runasp.net/api/people';

/**
 * Fetches all people from the server.
 * @returns {Promise<void>}
 * 
 * Example Usage:
 * getAllPeople(); // Fetches and logs all people
 */
export async function getAllPeople() {
  try {
    const response = await fetch(peopleBaseUrl, {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
      },
    });

    if (!response.ok) {
      throw new Error(`Error: ${response.statusText}`);
    }

    const people = await response.json();
    console.log(people); // Handle/display the people data
  } catch (error) {
    console.error('Failed to fetch people:', error);
  }
}

/**
 * Fetches a person by their ID.
 * @param {number} personId - The ID of the person to fetch.
 * @returns {Promise<void>}
 * 
 * Example Usage:
 * getPersonById(1); // Fetches and logs person with ID 1
 */
export async function getPersonById(personId) {
  try {
    const response = await fetch(`${peopleBaseUrl}/${personId}`, {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
      },
    });

    if (!response.ok) {
      throw new Error(`Error: ${response.statusText}`);
    }

    const person = await response.json();
    console.log(person); // Handle/display the person data
  } catch (error) {
    console.error(`Failed to fetch person with ID ${personId}:`, error);
  }
}

/**
 * Adds a new person to the system.
 * @param {object} newPerson - The person object to be added.
 * @returns {Promise<void>}
 * 
 * Example Usage:
 * const newPerson = {
 *   firstName: 'John',
 *   lastName: 'Doe',
 *   email: 'john.doe@example.com'
 * };
 * addPerson(newPerson); // Adds the person and logs the created person
 */
export async function addPerson(newPerson) {
  try {
    const response = await fetch(peopleBaseUrl, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(newPerson),
    });

    if (!response.ok) {
      throw new Error(`Error: ${response.statusText}`);
    }

    const person = await response.json();
    console.log('Person added:', person); // Handle the newly created person
  } catch (error) {
    console.error('Failed to add person:', error);
  }
}

/**
 * Updates an existing person in the system.
 * @param {number} personId - The ID of the person to update.
 * @param {object} updatedPerson - The updated person object.
 * @returns {Promise<void>}
 * 
 * Example Usage:
 * const updatedPerson = {
 *   firstName: 'John',
 *   lastName: 'Smith',
 *   email: 'john.smith@example.com'
 * };
 * updatePerson(1, updatedPerson); // Updates person with ID 1
 */
export async function updatePerson(personId, updatedPerson) {
  try {
    const response = await fetch(`${peopleBaseUrl}/${personId}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(updatedPerson),
    });

    if (!response.ok) {
      throw new Error(`Error: ${response.statusText}`);
    }

    const person = await response.json();
    console.log('Person updated:', person); // Handle/display the updated person
  } catch (error) {
    console.error(`Failed to update person with ID ${personId}:`, error);
  }
}

/**
 * Deletes a person by their ID.
 * @param {number} personId - The ID of the person to delete.
 * @returns {Promise<void>}
 * 
 * Example Usage:
 * deletePerson(1); // Deletes person with ID 1
 */
export async function deletePerson(personId) {
  try {
    const response = await fetch(`${peopleBaseUrl}/${personId}`, {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json',
      },
    });

    if (!response.ok) {
      throw new Error(`Error: ${response.statusText}`);
    }

    console.log(`Person with ID ${personId} deleted successfully.`);
  } catch (error) {
    console.error(`Failed to delete person with ID ${personId}:`, error);
  }
}
