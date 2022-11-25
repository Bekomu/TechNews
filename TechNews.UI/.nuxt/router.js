import Vue from 'vue'
import Router from 'vue-router'
import { normalizeURL, decode } from 'ufo'
import { interopDefault } from './utils'
import scrollBehavior from './router.scrollBehavior.js'

const _3aab3f92 = () => interopDefault(import('..\\pages\\home\\index.vue' /* webpackChunkName: "pages/home/index" */))
const _0ab5c9da = () => interopDefault(import('..\\pages\\login\\index.vue' /* webpackChunkName: "pages/login/index" */))
const _3ffb291e = () => interopDefault(import('..\\pages\\news\\index.vue' /* webpackChunkName: "pages/news/index" */))
const _46ad37ce = () => interopDefault(import('..\\pages\\register\\index.vue' /* webpackChunkName: "pages/register/index" */))
const _53b1124c = () => interopDefault(import('..\\pages\\components\\latestNewsBox.vue' /* webpackChunkName: "pages/components/latestNewsBox" */))
const _50a5e849 = () => interopDefault(import('..\\pages\\components\\loginBox.vue' /* webpackChunkName: "pages/components/loginBox" */))
const _3aae9b88 = () => interopDefault(import('..\\pages\\components\\manageNewsBox.vue' /* webpackChunkName: "pages/components/manageNewsBox" */))
const _1f414cbe = () => interopDefault(import('..\\pages\\components\\newsBox.vue' /* webpackChunkName: "pages/components/newsBox" */))
const _d123f65a = () => interopDefault(import('..\\pages\\components\\newsMain.vue' /* webpackChunkName: "pages/components/newsMain" */))
const _4372495e = () => interopDefault(import('..\\pages\\components\\registerBox.vue' /* webpackChunkName: "pages/components/registerBox" */))
const _22fd4322 = () => interopDefault(import('..\\pages\\news\\create\\index.vue' /* webpackChunkName: "pages/news/create/index" */))
const _089429da = () => interopDefault(import('..\\pages\\news\\delete\\index.vue' /* webpackChunkName: "pages/news/delete/index" */))
const _70750358 = () => interopDefault(import('..\\pages\\news\\edit\\index.vue' /* webpackChunkName: "pages/news/edit/index" */))
const _318955e7 = () => interopDefault(import('..\\pages\\news\\delete\\_id\\index.vue' /* webpackChunkName: "pages/news/delete/_id/index" */))
const _43aeb974 = () => interopDefault(import('..\\pages\\news\\edit\\_id\\index.vue' /* webpackChunkName: "pages/news/edit/_id/index" */))
const _5027ba91 = () => interopDefault(import('..\\pages\\index.vue' /* webpackChunkName: "pages/index" */))

const emptyFn = () => {}

Vue.use(Router)

export const routerOptions = {
  mode: 'history',
  base: '/',
  linkActiveClass: 'nuxt-link-active',
  linkExactActiveClass: 'nuxt-link-exact-active',
  scrollBehavior,

  routes: [{
    path: "/home",
    component: _3aab3f92,
    name: "home"
  }, {
    path: "/login",
    component: _0ab5c9da,
    name: "login"
  }, {
    path: "/news",
    component: _3ffb291e,
    name: "news"
  }, {
    path: "/register",
    component: _46ad37ce,
    name: "register"
  }, {
    path: "/components/latestNewsBox",
    component: _53b1124c,
    name: "components-latestNewsBox"
  }, {
    path: "/components/loginBox",
    component: _50a5e849,
    name: "components-loginBox"
  }, {
    path: "/components/manageNewsBox",
    component: _3aae9b88,
    name: "components-manageNewsBox"
  }, {
    path: "/components/newsBox",
    component: _1f414cbe,
    name: "components-newsBox"
  }, {
    path: "/components/newsMain",
    component: _d123f65a,
    name: "components-newsMain"
  }, {
    path: "/components/registerBox",
    component: _4372495e,
    name: "components-registerBox"
  }, {
    path: "/news/create",
    component: _22fd4322,
    name: "news-create"
  }, {
    path: "/news/delete",
    component: _089429da,
    name: "news-delete"
  }, {
    path: "/news/edit",
    component: _70750358,
    name: "news-edit"
  }, {
    path: "/news/delete/:id",
    component: _318955e7,
    name: "news-delete-id"
  }, {
    path: "/news/edit/:id",
    component: _43aeb974,
    name: "news-edit-id"
  }, {
    path: "/",
    component: _5027ba91,
    name: "index"
  }],

  fallback: false
}

export function createRouter (ssrContext, config) {
  const base = (config._app && config._app.basePath) || routerOptions.base
  const router = new Router({ ...routerOptions, base  })

  // TODO: remove in Nuxt 3
  const originalPush = router.push
  router.push = function push (location, onComplete = emptyFn, onAbort) {
    return originalPush.call(this, location, onComplete, onAbort)
  }

  const resolve = router.resolve.bind(router)
  router.resolve = (to, current, append) => {
    if (typeof to === 'string') {
      to = normalizeURL(to)
    }
    return resolve(to, current, append)
  }

  return router
}
