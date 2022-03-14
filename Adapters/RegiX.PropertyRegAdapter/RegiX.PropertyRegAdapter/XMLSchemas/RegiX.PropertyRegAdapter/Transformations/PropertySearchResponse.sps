<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="cm" uri="http://egov.bg/RegiX/AV/PropertyReg"/>			<nspair prefix="n1" uri="http://egov.bg/RegiX/AV/PropertyReg/PropertySearchResponse"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\eGov\RegiX\RegiX.PropertyRegAdapter\XMLSchemas\PropertySearchResponse.xsd" workingxmlfile="PropertySearchResponse.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<template match="n1:PropertySearchResponse" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<paragraph paragraphtag="h3">										<properties align="center"/>										<children>											<text fixtext="Агенция по вписванията"/>										</children>									</paragraph>									<paragraph paragraphtag="h2">										<properties align="center"/>										<children>											<text fixtext="Резултати от търсене на имот"/>										</children>									</paragraph>									<condition>										<children>											<conditionbranch xpath="string-length(.) = 0">												<children>													<text fixtext="Не са намерени данни за имот, отговарящ на въведените критерии!"/>													<newline/>													<text fixtext=" "/>													<newline/>													<text fixtext="Справката изпълнява търсене в информационните системи на съответните служби по вписвания. Справка за периода преди старта на информационна система, може да направите само и единствено на място в архива на съответната служба по вписванията по местонахождение на имота."/>													<newline/>													<text fixtext="Информация за старта на информационните системи на службите по вписвания, може да получите в "/>													<text fixtext="Справка за година на стартиране на информационните системи в Службите по вписванията">														<styles font-style="italic"/>													</text>													<text fixtext="."/>												</children>											</conditionbranch>											<conditionbranch>												<children>													<template match="n1:PropertyDetailList" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<paragraph>																<children>																	<template match="cm:PropertyDetail" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<line/>																			<template match="cm:PropertyID" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<table>																						<properties border="0" class="table-responsive" width="100%"/>																						<children>																							<tablebody>																								<children>																									<tablerow>																										<properties valign="top"/>																										<children>																											<tablecell headercell="1">																												<properties align="left" width="270px"/>																												<children>																													<text fixtext="Системен идентификатор на имот">																														<styles font-style="italic" font-weight="normal"/>																													</text>																												</children>																											</tablecell>																											<tablecell>																												<children>																													<content/>																												</children>																											</tablecell>																										</children>																									</tablerow>																								</children>																							</tablebody>																						</children>																					</table>																				</children>																			</template>																			<table>																				<properties border="0" class="table-responsive" width="100%"/>																				<children>																					<tablebody>																						<children>																							<tablerow>																								<properties valign="top"/>																								<children>																									<tablecell headercell="1">																										<properties align="left" width="270px"/>																										<children>																											<template match="cm:RegistryAgency" matchtype="schemagraphitem">																												<editorproperties elementstodisplay="5"/>																												<children>																													<content>																														<styles font-style="italic" font-weight="normal"/>																													</content>																												</children>																											</template>																										</children>																									</tablecell>																									<tablecell>																										<children>																											<template match="cm:SiteStartDate" matchtype="schemagraphitem">																												<editorproperties elementstodisplay="5"/>																												<children>																													<text fixtext="Година на стартиране на информационна система: ">																														<styles font-style="italic"/>																													</text>																													<content>																														<styles font-style="normal"/>																														<format string="YYYY"/>																													</content>																													<text fixtext=" г.*"/>																												</children>																											</template>																										</children>																									</tablecell>																								</children>																							</tablerow>																						</children>																					</tablebody>																				</children>																			</table>																			<template match="cm:LotNumber" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<table>																						<properties border="0" class="table-responsive" width="100%"/>																						<children>																							<tablebody>																								<children>																									<tablerow>																										<properties valign="top"/>																										<children>																											<tablecell headercell="1">																												<properties align="left" width="270px"/>																												<children>																													<text fixtext="Партида №">																														<styles font-style="italic" font-weight="normal"/>																													</text>																												</children>																											</tablecell>																											<tablecell>																												<children>																													<content/>																												</children>																											</tablecell>																										</children>																									</tablerow>																								</children>																							</tablebody>																						</children>																					</table>																				</children>																			</template>																			<template match="cm:OldLotNumber" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<table>																						<properties border="0" class="table-responsive" width="100%"/>																						<children>																							<tablebody>																								<children>																									<tablerow>																										<properties valign="top"/>																										<children>																											<tablecell headercell="1">																												<properties align="left" width="270px"/>																												<children>																													<text fixtext="Стара имотна партида">																														<styles font-style="italic" font-weight="normal"/>																													</text>																												</children>																											</tablecell>																											<tablecell>																												<children>																													<content/>																												</children>																											</tablecell>																										</children>																									</tablerow>																								</children>																							</tablebody>																						</children>																					</table>																				</children>																			</template>																			<template match="cm:CadastreNumber" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<table>																						<properties border="0" class="table-responsive" width="100%"/>																						<children>																							<tablebody>																								<children>																									<tablerow>																										<properties valign="top"/>																										<children>																											<tablecell headercell="1">																												<properties align="left" width="270px"/>																												<children>																													<text fixtext="Кадастрален идентификатор">																														<styles font-style="italic" font-weight="normal"/>																													</text>																												</children>																											</tablecell>																											<tablecell>																												<children>																													<content/>																												</children>																											</tablecell>																										</children>																									</tablerow>																								</children>																							</tablebody>																						</children>																					</table>																				</children>																			</template>																			<template match="cm:SecondCadastreNumber" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<table>																						<properties border="0" class="table-responsive" width="100%"/>																						<children>																							<tablebody>																								<children>																									<tablerow>																										<properties valign="top"/>																										<children>																											<tablecell headercell="1">																												<properties align="left" width="270px"/>																												<children>																													<text fixtext="Втори кадастрален идентификатор">																														<styles font-style="italic" font-weight="normal"/>																													</text>																												</children>																											</tablecell>																											<tablecell>																												<children>																													<content/>																												</children>																											</tablecell>																										</children>																									</tablerow>																								</children>																							</tablebody>																						</children>																					</table>																				</children>																			</template>																			<template match="cm:PropertyType" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<table>																						<properties border="0" class="table-responsive" width="100%"/>																						<children>																							<tablebody>																								<children>																									<tablerow>																										<properties valign="top"/>																										<children>																											<tablecell headercell="1">																												<properties align="left" width="270px"/>																												<children>																													<text fixtext="Вид имот">																														<styles font-style="italic" font-weight="normal"/>																													</text>																												</children>																											</tablecell>																											<tablecell>																												<children>																													<content/>																												</children>																											</tablecell>																										</children>																									</tablerow>																								</children>																							</tablebody>																						</children>																					</table>																				</children>																			</template>																			<template match="cm:DistrictName" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<table>																						<properties border="0" class="table-responsive" width="100%"/>																						<children>																							<tablebody>																								<children>																									<tablerow>																										<properties valign="top"/>																										<children>																											<tablecell headercell="1">																												<properties align="left" width="270px"/>																												<children>																													<text fixtext="Област">																														<styles font-style="italic" font-weight="normal"/>																													</text>																												</children>																											</tablecell>																											<tablecell>																												<children>																													<content/>																												</children>																											</tablecell>																										</children>																									</tablerow>																								</children>																							</tablebody>																						</children>																					</table>																				</children>																			</template>																			<template match="cm:MunicipalityName" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<table>																						<properties border="0" class="table-responsive" width="100%"/>																						<children>																							<tablebody>																								<children>																									<tablerow>																										<properties valign="top"/>																										<children>																											<tablecell headercell="1">																												<properties align="left" width="270px"/>																												<children>																													<text fixtext="Община">																														<styles font-style="italic" font-weight="normal"/>																													</text>																												</children>																											</tablecell>																											<tablecell>																												<children>																													<content/>																												</children>																											</tablecell>																										</children>																									</tablerow>																								</children>																							</tablebody>																						</children>																					</table>																				</children>																			</template>																			<template match="cm:TerritorialUnitName" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<table>																						<properties border="0" class="table-responsive" width="100%"/>																						<children>																							<tablebody>																								<children>																									<tablerow>																										<properties valign="top"/>																										<children>																											<tablecell headercell="1">																												<properties align="left" width="270px"/>																												<children>																													<text fixtext="Населено място">																														<styles font-style="italic" font-weight="normal"/>																													</text>																												</children>																											</tablecell>																											<tablecell>																												<children>																													<content/>																												</children>																											</tablecell>																										</children>																									</tablerow>																								</children>																							</tablebody>																						</children>																					</table>																				</children>																			</template>																			<table>																				<properties border="0" class="table-responsive" width="100%"/>																				<children>																					<tablebody>																						<children>																							<tablerow>																								<properties valign="top"/>																								<children>																									<tablecell headercell="1">																										<properties align="left" width="270px"/>																										<children>																											<text fixtext="Адрес">																												<styles font-style="italic" font-weight="normal"/>																											</text>																										</children>																									</tablecell>																									<tablecell>																										<children>																											<template match="cm:HousingEstate" matchtype="schemagraphitem">																												<editorproperties elementstodisplay="5"/>																												<children>																													<text fixtext="жк. "/>																													<content/>																												</children>																											</template>																											<template match="cm:NeighborhoodName" matchtype="schemagraphitem">																												<editorproperties elementstodisplay="5"/>																												<children>																													<text fixtext=" кв. "/>																													<content/>																												</children>																											</template>																											<template match="cm:StreetName" matchtype="schemagraphitem">																												<editorproperties elementstodisplay="5"/>																												<children>																													<text fixtext=" ул. "/>																													<content/>																												</children>																											</template>																											<template match="cm:StreetNumber" matchtype="schemagraphitem">																												<editorproperties elementstodisplay="5"/>																												<children>																													<text fixtext=" "/>																													<content/>																												</children>																											</template>																											<template match="cm:Block" matchtype="schemagraphitem">																												<editorproperties elementstodisplay="5"/>																												<children>																													<text fixtext=", бл. "/>																													<content/>																												</children>																											</template>																											<template match="cm:Entrance" matchtype="schemagraphitem">																												<editorproperties elementstodisplay="5"/>																												<children>																													<text fixtext=", вх. "/>																													<content/>																												</children>																											</template>																											<template match="cm:Floor" matchtype="schemagraphitem">																												<editorproperties elementstodisplay="5"/>																												<children>																													<text fixtext=", ет."/>																													<content/>																												</children>																											</template>																											<template match="cm:Appartment" matchtype="schemagraphitem">																												<editorproperties elementstodisplay="5"/>																												<children>																													<text fixtext=", ап. "/>																													<content/>																												</children>																											</template>																											<template match="cm:PostBox" matchtype="schemagraphitem">																												<editorproperties elementstodisplay="5"/>																												<children>																													<text fixtext=", п.к."/>																													<content/>																												</children>																											</template>																										</children>																									</tablecell>																								</children>																							</tablerow>																						</children>																					</tablebody>																				</children>																			</table>																			<template match="cm:Remark" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<table>																						<properties border="0" class="table-responsive" width="100%"/>																						<children>																							<tablebody>																								<children>																									<tablerow>																										<properties valign="top"/>																										<children>																											<tablecell headercell="1">																												<properties align="left" width="270px"/>																												<children>																													<text fixtext="Забележка">																														<styles font-style="italic" font-weight="normal"/>																													</text>																												</children>																											</tablecell>																											<tablecell>																												<children>																													<content/>																												</children>																											</tablecell>																										</children>																									</tablerow>																								</children>																							</tablebody>																						</children>																					</table>																				</children>																			</template>																		</children>																		<sort>																			<key match="cm:RegistryAgency"/>																			<key match="cm:DistrictName"/>																			<key match="cm:MunicipalityName"/>																			<key match="cm:TerritorialUnitName"/>																			<key match="cm:HousingEstate"/>																			<key match="cm:NeighborhoodName"/>																			<key match="cm:StreetName"/>																			<key match="cm:StreetNumber"/>																			<key match="cm:Block"/>																			<key match="cm:Floor"/>																			<key match="cm:Appartment"/>																			<key match="cm:PostBox"/>																		</sort>																	</template>																</children>															</paragraph>															<newline/>															<text fixtext="* Справка за периода преди старта на информационна система, може да направите само и единствено на място в архива на съответната служба по вписванията по местонахождение на имота">																<styles font-style="italic"/>															</text>														</children>													</template>												</children>											</conditionbranch>										</children>									</condition>								</children>							</template>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>