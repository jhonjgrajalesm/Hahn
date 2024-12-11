<template>
  <div>
    <h1>Employee List</h1>    
    <ul v-if="!employeeStore.loading" class="list-group">
      <li v-for="employee in employeeStore.employees" :key="employee.id" class="list-group-item">
        <p>{{ employee.name }} - {{ employee.position }} - {{ employee.salary }}</p>
        <button @click="incrementSalary(employee.id)">Increment ($500)</button>
      </li>
    </ul>
    <p v-else>Loading...</p>
  </div>
</template>

<script setup lang="ts">
import { onMounted } from "vue";
import { useEmployeeStore } from "@/stores/employee";

// Access the store directly
const employeeStore = useEmployeeStore();

// Fetch employees when the component is mounted
onMounted(async () => {
  await employeeStore.fetchEmployees();  // Trigger action to fetch employees  
});

// Access the incrementSalary action from the store
const incrementSalary = async (id: string) => {
  employeeStore.incrementSalary(id); // Call incrementSalary from the store
  await employeeStore.fetchEmployees(); 
};
</script>
