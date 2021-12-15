import { createRouter, createWebHistory } from "vue-router";

const routes = [
  {
    path: "/",
    name: "Home",
    meta: {
      requiresData: true,
    },
    component: () => import("../views/Home.vue"),
  },
  {
    path: "/details",
    name: "Details",
    meta: {
      requiresData: true,
    },
    component: () => import("../views/Details.vue"),
  },
  {
    path: "/select",
    name: "Select",
    component: () => import("../views/Select.vue"),
  },
  {
    path: "/connectionlost",
    name: "ConnectionLost",
    component: () => import("../components/Common/ConnectionLost.vue"),
  },
  {
    path: "/:catchAll(.*)",
    component: () => import("../components/Common/NotFound.vue"),
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
