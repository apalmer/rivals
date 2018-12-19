import Vue from 'vue'
import Router from 'vue-router'
import World from './views/World.vue'
// eslint-disable-next-line
import Duel from './views/Duel.vue'
import Spike from './views/Spike.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'world',
      component: World
    },
    {
      path: '/duel/:duelId',
      name: 'duel',
      // component: Duel
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "duel" */ './views/Duel.vue')
    },
    {
      path: '/spike',
      name: 'spike',
      // component: Duel
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: Spike
    }
  ]
})
