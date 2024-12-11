<template> 

  <main>
    <div class="row">
      <img alt="Vue logo" class="logo" src="./assets/logo.svg" width="125" height="125" />
    </div>
    <div class="row">
      <EmployeeList />
      <AddEmployee />
    </div>
  </main>
</template>

<script lang="ts">

  import AddEmployee from "./components/AddEmployee.vue";
  import EmployeeList from "./components/EmployeeList.vue";

  export default {
    name: "App",
    components: {
      AddEmployee,
      EmployeeList,
    },
  };
</script>

<style scoped>
  header {
    line-height: 1.5;
  }

  .logo {
    display: block;
    margin: 0 auto 2rem;
  }

  @media (min-width: 1024px) {
    header {
      display: flex;
      place-items: center;
      padding-right: calc(var(--section-gap) / 2);
    }

    .logo {
      margin: 0 2rem 0 0;
    }

    header .wrapper {
      display: flex;
      place-items: flex-start;
      flex-wrap: wrap;
    }
  }
</style>
