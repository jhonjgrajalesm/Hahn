import axios from "axios";
import type { Employee } from "@/types/employee";

// Create an Axios instance with a base URL
const apiClient = axios.create({
  baseURL: "https://localhost:7011", // Ensure this matches your API's Swagger base URL
  timeout: 5000, // Optional: Set a timeout for API calls
});

export async function fetchEmployee(id: string): Promise<Employee | null> {
  try {
    // Call the API using the Axios instance
    const response = await apiClient.get<Employee>(`/Employee/${id}`);

    // Response data is automatically typed as Employee
    const employee: Employee = response.data;

    console.log("Employee fetched:", employee);
    return employee;
  } catch (error: any) {
    // Handle errors and log appropriately
    if (axios.isAxiosError(error)) {
      console.error("Axios error:", error.response?.status, error.response?.data);
    } else {
      console.error("Unexpected error:", error);
    }
    return null;
  }
}

export async function fetchEmployees(): Promise<Employee[] | null> {
  try {
    // Call the API using the Axios instance
    const response = await apiClient.get<Employee[]>(`/Employee`);

    // Response data is automatically typed as Employee
    const employees: Employee[] = response.data;

    return employees;
  } catch (error: any) {
    // Handle errors and log appropriately
    if (axios.isAxiosError(error)) {
      console.error("Axios error:", error.response?.status, error.response?.data);
    } else {
      console.error("Unexpected error:", error);
    }
    return null;
  }
}

export async function employeePost(employee: Employee): Promise<Employee | null> {
  try {    
    const response = await apiClient.post<Employee>(`/Employee`, employee, {
      headers: {
        'Content-Type': 'application/json',
      }
    });

    // Response data is automatically typed as Employee
    const employeeResponse: Employee = response.data;

    return employeeResponse;
  } catch (error: any) {
    // Handle errors and log appropriately
    if (axios.isAxiosError(error)) {
      console.error("Axios error:", error.response?.status, error.response?.data);
    } else {
      console.error("Unexpected error:", error);
    }
    return null;
  }
}


export async function employeePut(employee: Employee): Promise<Employee | null> {
  try {
    // Call the API using the Axios instance
    const response = await apiClient.put<Employee>(`/Employee`);

    // Response data is automatically typed as Employee
    const employee: Employee = response.data;

    return employee;
  } catch (error: any) {
    // Handle errors and log appropriately
    if (axios.isAxiosError(error)) {
      console.error("Axios error:", error.response?.status, error.response?.data);
    } else {
      console.error("Unexpected error:", error);
    }
    return null;
  }
}

export async function fetchEmployeeIncrement(id: string): Promise<Employee | null> {
  try {
    // Call the API using the Axios instance
    const response = await apiClient.get<Employee>(`/Employee/increment/${id}`);

    // Response data is automatically typed as Employee
    const employee: Employee = response.data;

    console.log("Employee fetched:", employee);
    return employee;
  } catch (error: any) {
    // Handle errors and log appropriately
    if (axios.isAxiosError(error)) {
      console.error("Axios error:", error.response?.status, error.response?.data);
    } else {
      console.error("Unexpected error:", error);
    }
    return null;
  }
}
