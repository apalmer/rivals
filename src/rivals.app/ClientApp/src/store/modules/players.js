export default {
  namespaced: true,
  state: {
    antagonist: {
      playerName: 'enemy',
      health: 100
    },
    protagonist: {
      playerName: 'self',
      health: 100
    },
    range: 2
  },
  mutations: {
    damageProtagonist (state, damage) {
      var newHealth = state.protagonist.health - damage
      if (newHealth < 0) {
        newHealth = 0
      }
      state.protagonist.health = newHealth
    },
    damageAntagonist (state, damage) {
      var newHealth = state.antagonist.health - damage
      if (newHealth < 0) {
        newHealth = 0
      }
      state.antagonist.health = newHealth
    },
    increaseRange (state, steps) {
      var newRange = state.range + steps
      if (newRange > 3) {
        newRange -= steps
      }
      state.range = newRange
    },
    decreaseRange (state, steps) {
      var newRange = state.range - steps
      if (newRange < 0) {
        newRange = 0
      }
      state.range = newRange
    }
  },
  actions: {
    asyncDamageProtagonist ({ state, commit, rootState }, damage) {
      commit('damageProtagonist', damage)
    },
    asyncDamageAntagonist ({ state, commit, rootState }, damage) {
      commit('damageAntagonist', damage)
    }
  },
  getters: {
    rangeDescription: (state, getters, rootState) => {
      var description
      switch (state.range) {
        case 0:
          description = 'ADJACENT'
          break
        case 1:
          description = 'NEAR'
          break
        case 2:
          description = 'FAR'
          break
        case 3:
          description = 'REMOTE'
          break
      }
      return description
    }
  }
}
