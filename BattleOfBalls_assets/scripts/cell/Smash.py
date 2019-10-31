# -*- coding: utf-8 -*-
import KBEngine
from KBEDebug import *

class Smash(KBEngine.Entity):
	def __init__(self):
		KBEngine.Entity.__init__(self)


	#实体销毁调用
	def onDestroy(self):
		KBEngine.globalData["Room_%i" % self.spaceID].onSmashDestroy(self.id)

	#返回实体类型
	def returnType(self):
		return 2


