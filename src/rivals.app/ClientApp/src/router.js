import Vue from 'vue'
import Router from 'vue-router'
import World from './views/World.vue'

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
      path: '/duel',
      name: 'duel',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "duel" */ './views/Duel.vue')
    }
  ]
})
