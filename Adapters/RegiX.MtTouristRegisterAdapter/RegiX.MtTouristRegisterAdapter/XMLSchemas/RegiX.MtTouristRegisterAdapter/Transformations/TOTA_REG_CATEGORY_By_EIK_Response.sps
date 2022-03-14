<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="common" uri="http://egov.bg/RegiX/MT/Common"/>			<nspair prefix="n1" uri="http://egov.bg/RegiX/MT/ObjectCategoryByEIKResponse"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\Projects\eGov\RegiX\RegiX.MtTouristRegisterAdapter\XMLSchemas\TOTA_REG_CATEGORY_By_EIK_Response.xsd" workingxmlfile="TOTA_REG_CATEGORY_By_EIK_Response.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<template match="n1:ObjectCategoryByEIKResponse" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<paragraph paragraphtag="h3">										<properties align="center"/>										<children>											<text fixtext="Министерство на туризма"/>											<newline/>											<text fixtext="Национален туристически регистър"/>										</children>									</paragraph>									<paragraph paragraphtag="h2">										<properties align="center"/>										<children>											<text fixtext="Справка за категоризация на обекти"/>										</children>									</paragraph>									<template match="n1:Objects" matchtype="schemagraphitem">										<editorproperties elementstodisplay="5"/>										<children>											<paragraph>												<properties align="left"/>												<styles font-size="small" font-weight="bold"/>												<children>													<text fixtext="Обект "/>													<autocalc xpath="position()">														<styles font-style="italic" font-weight="bold"/>													</autocalc>													<text fixtext=" от ">														<styles font-style="italic" font-weight="bold"/>													</text>													<autocalc xpath="count(   /n1:ObjectCategoryByEIKResponse/n1:Objects   )">														<styles font-style="italic" font-weight="bold"/>													</autocalc>												</children>											</paragraph>											<template match="n1:EIK" matchtype="schemagraphitem">												<editorproperties elementstodisplay="5"/>												<children>													<table>														<properties border="0" width="100%"/>														<children>															<tablebody>																<children>																	<tablerow>																		<properties valign="top"/>																		<children>																			<tablecell headercell="1">																				<properties align="left" width="250px"/>																				<children>																					<text fixtext="ЕИК/БУЛСТАТ">																						<styles font-style="italic" font-weight="normal"/>																					</text>																				</children>																			</tablecell>																			<tablecell>																				<children>																					<content>																						<format datatype="string"/>																					</content>																				</children>																			</tablecell>																		</children>																	</tablerow>																</children>															</tablebody>														</children>													</table>												</children>											</template>											<template match="n1:SiteName" matchtype="schemagraphitem">												<editorproperties elementstodisplay="5"/>												<children>													<table>														<properties border="0" width="100%"/>														<children>															<tablebody>																<children>																	<tablerow>																		<properties valign="top"/>																		<children>																			<tablecell headercell="1">																				<properties align="left" width="250px"/>																				<children>																					<text fixtext="Наименование">																						<styles font-style="italic" font-weight="normal"/>																					</text>																				</children>																			</tablecell>																			<tablecell>																				<children>																					<content>																						<format datatype="string"/>																					</content>																				</children>																			</tablecell>																		</children>																	</tablerow>																</children>															</tablebody>														</children>													</table>												</children>											</template>											<template match="n1:SiteKind" matchtype="schemagraphitem">												<editorproperties elementstodisplay="5"/>												<children>													<table>														<properties border="0" width="100%"/>														<children>															<tablebody>																<children>																	<tablerow>																		<properties valign="top"/>																		<children>																			<tablecell headercell="1">																				<properties align="left" width="250px"/>																				<children>																					<text fixtext="Вид">																						<styles font-style="italic" font-weight="normal"/>																					</text>																				</children>																			</tablecell>																			<tablecell>																				<children>																					<content>																						<format datatype="string"/>																					</content>																				</children>																			</tablecell>																		</children>																	</tablerow>																</children>															</tablebody>														</children>													</table>												</children>											</template>											<template match="n1:SiteType" matchtype="schemagraphitem">												<editorproperties elementstodisplay="5"/>												<children>													<table>														<properties border="0" width="100%"/>														<children>															<tablebody>																<children>																	<tablerow>																		<properties valign="top"/>																		<children>																			<tablecell headercell="1">																				<properties align="left" width="250px"/>																				<children>																					<text fixtext="Тип">																						<styles font-style="italic" font-weight="normal"/>																					</text>																				</children>																			</tablecell>																			<tablecell>																				<children>																					<content>																						<format datatype="string"/>																					</content>																				</children>																			</tablecell>																		</children>																	</tablerow>																</children>															</tablebody>														</children>													</table>												</children>											</template>											<template match="n1:SiteSubType" matchtype="schemagraphitem">												<editorproperties elementstodisplay="5"/>												<children>													<table>														<properties border="0" width="100%"/>														<children>															<tablebody>																<children>																	<tablerow>																		<properties valign="top"/>																		<children>																			<tablecell headercell="1">																				<properties align="left" width="250px"/>																				<children>																					<text fixtext="Подтип">																						<styles font-style="italic" font-weight="normal"/>																					</text>																				</children>																			</tablecell>																			<tablecell>																				<children>																					<content>																						<format datatype="string"/>																					</content>																				</children>																			</tablecell>																		</children>																	</tablerow>																</children>															</tablebody>														</children>													</table>												</children>											</template>											<template match="n1:Category" matchtype="schemagraphitem">												<editorproperties elementstodisplay="5"/>												<children>													<table>														<properties border="0" width="100%"/>														<children>															<tablebody>																<children>																	<tablerow>																		<properties valign="top"/>																		<children>																			<tablecell headercell="1">																				<properties align="left" width="250px"/>																				<children>																					<text fixtext="Категория">																						<styles font-style="italic" font-weight="normal"/>																					</text>																				</children>																			</tablecell>																			<tablecell>																				<children>																					<content>																						<format datatype="int"/>																					</content>																				</children>																			</tablecell>																		</children>																	</tablerow>																</children>															</tablebody>														</children>													</table>												</children>											</template>											<template match="n1:Adress" matchtype="schemagraphitem">												<editorproperties elementstodisplay="5"/>												<children>													<paragraph>														<children>															<text fixtext="Адрес">																<styles font-weight="bold"/>															</text>														</children>													</paragraph>													<template match="common:DistName" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Област">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>													<template match="common:TerName" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Община">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>													<template match="common:PopName" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Населено място">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>													<template match="common:Adress" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Адрес">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>													<template match="common:Phone" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Телефон">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>													<template match="common:Fax" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Факс">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>												</children>											</template>											<template match="n1:Capacity" matchtype="schemagraphitem">												<editorproperties elementstodisplay="5"/>												<children>													<paragraph>														<children>															<text fixtext="Капацитет">																<styles font-weight="bold"/>															</text>														</children>													</paragraph>													<template match="common:Capacity" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Определен капацитет">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format datatype="int"/>																							</content>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>													<template match="common:IndoorsCapacity" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Капацитет на закрито">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format datatype="int"/>																							</content>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>													<template match="common:OutdoorsCapacity" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Капацитет на открито">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format datatype="int"/>																							</content>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>												</children>											</template>											<template match="n1:RoomsNumber" matchtype="schemagraphitem">												<editorproperties elementstodisplay="5"/>												<children>													<table>														<properties border="0" width="100%"/>														<children>															<tablebody>																<children>																	<tablerow>																		<properties valign="top"/>																		<children>																			<tablecell headercell="1">																				<properties align="left" width="250px"/>																				<children>																					<text fixtext="Брой стаи">																						<styles font-style="italic" font-weight="normal"/>																					</text>																				</children>																			</tablecell>																			<tablecell>																				<children>																					<content>																						<format datatype="int"/>																					</content>																				</children>																			</tablecell>																		</children>																	</tablerow>																</children>															</tablebody>														</children>													</table>												</children>											</template>											<template match="n1:BedsNumber" matchtype="schemagraphitem">												<editorproperties elementstodisplay="5"/>												<children>													<table>														<properties border="0" width="100%"/>														<children>															<tablebody>																<children>																	<tablerow>																		<properties valign="top"/>																		<children>																			<tablecell headercell="1">																				<properties align="left" width="250px"/>																				<children>																					<text fixtext="Брой легла">																						<styles font-style="italic" font-weight="normal"/>																					</text>																				</children>																			</tablecell>																			<tablecell>																				<children>																					<content>																						<format datatype="int"/>																					</content>																				</children>																			</tablecell>																		</children>																	</tablerow>																</children>															</tablebody>														</children>													</table>												</children>											</template>											<template match="n1:WorkTime" matchtype="schemagraphitem">												<editorproperties elementstodisplay="5"/>												<children>													<table>														<properties border="0" width="100%"/>														<children>															<tablebody>																<children>																	<tablerow>																		<properties valign="top"/>																		<children>																			<tablecell headercell="1">																				<properties align="left" width="250px"/>																				<children>																					<text fixtext="Работно време">																						<styles font-style="italic" font-weight="normal"/>																					</text>																				</children>																			</tablecell>																			<tablecell>																				<children>																					<content>																						<format datatype="string"/>																					</content>																				</children>																			</tablecell>																		</children>																	</tablerow>																</children>															</tablebody>														</children>													</table>												</children>											</template>											<condition>												<children>													<conditionbranch xpath="count ( /n1:ObjectCategoryByEIKResponse/n1:Objects )&gt;0">														<children>															<template match="n1:Subobjects" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<paragraph>																		<children>																			<text fixtext="Подразделения">																				<styles font-weight="bold"/>																			</text>																		</children>																	</paragraph>																	<table>																		<properties border="1"/>																		<styles border-collapse="collapse"/>																		<children>																			<tableheader>																				<children>																					<tablerow>																						<children>																							<tablecell headercell="1">																								<properties align="left"/>																								<children>																									<text fixtext="Описание">																										<styles font-style="italic" font-weight="normal"/>																									</text>																								</children>																							</tablecell>																							<tablecell headercell="1">																								<properties align="left" width="140"/>																								<children>																									<text fixtext="Тип">																										<styles font-style="italic" font-weight="normal"/>																									</text>																								</children>																							</tablecell>																						</children>																					</tablerow>																				</children>																			</tableheader>																			<tablebody>																				<children>																					<template match="n1:Subobject" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<tablerow>																								<children>																									<tablecell>																										<children>																											<template match="common:Description" matchtype="schemagraphitem">																												<editorproperties elementstodisplay="5"/>																												<children>																													<content>																														<format datatype="string"/>																													</content>																												</children>																											</template>																										</children>																									</tablecell>																									<tablecell>																										<properties width="140"/>																										<children>																											<template match="common:Type" matchtype="schemagraphitem">																												<editorproperties elementstodisplay="5"/>																												<children>																													<content>																														<format datatype="string"/>																													</content>																												</children>																											</template>																										</children>																									</tablecell>																								</children>																							</tablerow>																						</children>																					</template>																				</children>																			</tablebody>																		</children>																	</table>																</children>															</template>														</children>													</conditionbranch>												</children>											</condition>											<template match="n1:Certificate" matchtype="schemagraphitem">												<editorproperties elementstodisplay="5"/>												<children>													<paragraph>														<children>															<text fixtext="Удостоверение за категория">																<styles font-weight="bold"/>															</text>														</children>													</paragraph>													<template match="common:CategoryCertNum" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Номер">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>													<template match="common:CategoryCertDate" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Дата">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format string="DD.MM.YYYY" datatype="date"/>																							</content>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>													<template match="common:ValidityTerm" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Срок на валидност">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format string="DD.MM.YYYY" datatype="date"/>																							</content>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>												</children>											</template>											<newline/>										</children>									</template>								</children>							</template>							<template match="n1:ObjectCategoryByEIKResponse" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<template match="n1:Objects" matchtype="schemagraphitem">										<editorproperties elementstodisplay="5"/>									</template>								</children>							</template>							<newline/>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>