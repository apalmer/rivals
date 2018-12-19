<template>
  <transition name="modal">
      <div class="modal-mask">
        <div class="modal-dialog-centered">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <slot name="header">
                  <h5 class="modal-title">Modal title</h5>
                  <button type="button" class="close" aria-label="Close" @click="close">
                    <span aria-hidden="true">&times;</span>
                  </button>
                </slot>
              </div>
              <div class="modal-body">
                <slot name="body">
                </slot>
              </div>
              <div class="modal-footer">
                <slot name="footer">
                  <button type="button" class="btn btn-primary" @click="close">Cancel</button>
                </slot>
              </div>
            </div>
          </div>
        </div>
      </div>
    </transition>
</template>

<script>
export default {
  name: 'Modal',
  methods: {
    close () {
      this.$emit('close-modal')
    }
  }
}
</script>

<style scoped>
  .modal-mask {
    position: fixed;
    z-index: 9998;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, .5);
    display: table;
    transition: opacity .3s ease;
  }

</style>
