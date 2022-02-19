<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <p>
      "Dhee.AI Demo Leave Application" demonstrates how to build your first Bot.
    </p>
    <h3>What it does</h3>
    <ul>
      <li>Requests for your current Leave status</li>
      <li>Raise your leave request</li>
    </ul>
  </div>
</template>

<script>
export default {
  name: "LandingPage",
  props: {
    msg: String,
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  margin: 0;
  padding: 0;
  list-style: none;
}

li {
  padding-right: 5px;
}
a {
  color: #42b983;
}
</style>
