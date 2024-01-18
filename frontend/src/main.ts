import {
  createVuesticEssential,
  VaButton,
  VaDataTable,
  VaDateInput,
  VaInput,
  VaModal,
  VaList,
  VaListLabel,
  VaListItemSection,
  VaListItemLabel,
  VaForm,
  VaTextarea,
  VaCard,
  VaCardTitle,
  VaCardContent,
  VaSelect,
} from "vuestic-ui";
import "vuestic-ui/styles/essential.css";
import "vuestic-ui/styles/typography.css";
import "./assets/main.css";

import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";

const app = createApp(App);

app.use(router);

app.use(
  createVuesticEssential({
    components: {
      VaButton,
      VaDataTable,
      VaModal,
      VaInput,
      VaDateInput,
      VaList,
      VaListLabel,
      VaListItemSection,
      VaListItemLabel,
      VaForm,
      VaTextarea,
      VaCardContent,
      VaCardTitle,
      VaCard,
      VaSelect,
    },
  })
);
app.mount("#app");
