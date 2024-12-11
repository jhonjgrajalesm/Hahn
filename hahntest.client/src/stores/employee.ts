import { defineStore } from "pinia";
import { fetchEmployee, fetchEmployees, employeePost, employeePut, fetchEmployeeIncrement } from "@/api/api"; // Import generated API client
import type { Employee } from "@/types/employee"; // Use type-only import

export const useEmployeeStore = defineStore("employee", {
  state: () => ({
    employees: [] as Employee[] | null,
    loading: false,
  }),

  actions: {
    async fetchEmployees() {
      this.loading = true;
      try {
        this.employees = await fetchEmployees();
      } finally {
        this.loading = false;
      }
    },

    async addEmployee(newEmployee: Employee) {
      const employee = await employeePost(newEmployee);
      if (employee && this.employees) {
        this.employees.push(employee);
      }
    },

    async updateEmployee(updatedEmployee: Employee) {
      await employeePut(updatedEmployee);
      if (this.employees) {
        const index = this.employees.findIndex((e) => e.id === updatedEmployee.id);
        if (index !== -1) {
          this.employees.splice(index, 1, updatedEmployee);
        }
      }
    },

    async incrementSalary(id: string | null) {
      if (id) {
        await fetchEmployeeIncrement(id);
      }
    },
  },
});
