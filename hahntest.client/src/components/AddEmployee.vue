<template>
  <div class="container mt-5">
    <h1 class="mb-4">Add Employee</h1>
    <form @submit.prevent="addEmployee">
      <!-- Name Input -->
      <div class="mb-3">
        <label for="employeeName" class="form-label">Name:</label>
        <input type="text" class="form-control" id="employeeName" v-model="employee.name" required />
      </div>

      <!-- Position Input -->
      <div class="mb-3">
        <label for="employeePosition" class="form-label">Position:</label>
        <input type="text" class="form-control" id="employeePosition" v-model="employee.position" required />
      </div>

      <!-- Salary Input -->
      <div class="mb-3">
        <label for="employeeSalary" class="form-label">Salary:</label>
        <input type="number" class="form-control" id="employeeSalary" v-model="employee.salary" required />
      </div>

      <!-- Submit Button -->
      <button type="submit" class="btn btn-primary">Add</button>
    </form>
  </div>
</template>
  
  <script setup lang="ts">
  import { reactive } from "vue";
  import { useEmployeeStore } from "@/stores/employee";
  
  const employeeStore = useEmployeeStore();
  const employee = reactive({ id:"",  name: "", position: "", salary: 0.0 });
  
  const addEmployee = () => {    
    employeeStore.addEmployee(employee);
    employeeStore.fetchEmployees();
  };
  </script>
