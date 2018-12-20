import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    remainingRoundTime: 15
  },
  mutations: {
    decrement (state) {
      state.remainingRoundTime--
    }
  },
  actions: {

  }
})
